using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL133
{
    [TLObject(399807445)]
    public class TLChannelForbidden : TLAbsChat
    {
        public override int Constructor
        {
            get
            {
                return 399807445;
            }
        }

        public bool Broadcast { get; set; }
        public bool Megagroup { get; set; }
        public long AccessHash { get; set; }
        public int? UntilDate { get; set; }


        public void ComputeFlags()
        {
            Flags = 0;
            Flags = Broadcast ? (Flags | 32) : (Flags & ~32);
            Flags = Megagroup ? (Flags | 256) : (Flags & ~256);
            Flags = UntilDate != null ? (Flags | 65536) : (Flags & ~65536);

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
            Broadcast = (Flags & 32) != 0;
            Megagroup = (Flags & 256) != 0;
            Id = br.ReadInt64();
            AccessHash = br.ReadInt64();
            Title = StringUtil.Deserialize(br);
            if ((Flags & 65536) != 0)
                UntilDate = br.ReadInt32();
            else
                UntilDate = null;


        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ComputeFlags();
            bw.Write(Flags);


            bw.Write(Id);
            bw.Write(AccessHash);
            StringUtil.Serialize(Title, bw);
            if ((Flags & 65536) != 0)
                bw.Write(UntilDate.Value);

        }
    }
}
