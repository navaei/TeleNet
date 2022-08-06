using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL123.Messages
{
    [TLObject(1578088377)]
    public class TLHistoryImportParsed : TLObject
    {
        public override int Constructor
        {
            get
            {
                return 1578088377;
            }
        }

        public int Flags { get; set; }
        public bool Pm { get; set; }
        public bool Group { get; set; }
        public string Title { get; set; }


        public void ComputeFlags()
        {
            Flags = 0;
            Flags = Pm ? (Flags | 1) : (Flags & ~1);
            Flags = Group ? (Flags | 2) : (Flags & ~2);
            Flags = Title != null ? (Flags | 4) : (Flags & ~4);

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
            Pm = (Flags & 1) != 0;
            Group = (Flags & 2) != 0;
            if ((Flags & 4) != 0)
                Title = StringUtil.Deserialize(br);
            else
                Title = null;


        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ComputeFlags();
            bw.Write(Flags);


            if ((Flags & 4) != 0)
                StringUtil.Serialize(Title, bw);

        }
    }
}
