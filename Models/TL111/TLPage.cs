using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL111
{
    [TLObject(-1738178803)]
    public class TLPage : TLAbsPage
    {
        public override int Constructor
        {
            get
            {
                return -1738178803;
            }
        }

        public int Flags { get; set; }
        public bool Part { get; set; }
        public bool Rtl { get; set; }
        public bool V2 { get; set; }
        public string Url { get; set; }
        public TLVector<TLAbsPageBlock> Blocks { get; set; }
        public TLVector<TLAbsPhoto> Photos { get; set; }
        public TLVector<TLAbsDocument> Documents { get; set; }
        public int? Views { get; set; }


        public void ComputeFlags()
        {
            Flags = 0;
            Flags = Part ? (Flags | 1) : (Flags & ~1);
            Flags = Rtl ? (Flags | 2) : (Flags & ~2);
            Flags = V2 ? (Flags | 4) : (Flags & ~4);
            Flags = Views != null ? (Flags | 8) : (Flags & ~8);

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
            Part = (Flags & 1) != 0;
            Rtl = (Flags & 2) != 0;
            V2 = (Flags & 4) != 0;
            Url = StringUtil.Deserialize(br);
            Blocks = (TLVector<TLAbsPageBlock>)ObjectUtils.DeserializeVector<TLAbsPageBlock>(br);
            Photos = (TLVector<TLAbsPhoto>)ObjectUtils.DeserializeVector<TLAbsPhoto>(br);
            Documents = (TLVector<TLAbsDocument>)ObjectUtils.DeserializeVector<TLAbsDocument>(br);
            if ((Flags & 8) != 0)
                Views = br.ReadInt32();
            else
                Views = null;


        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ComputeFlags();
            bw.Write(Flags);



            StringUtil.Serialize(Url, bw);
            ObjectUtils.SerializeObject(Blocks, bw);
            ObjectUtils.SerializeObject(Photos, bw);
            ObjectUtils.SerializeObject(Documents, bw);
            if ((Flags & 8) != 0)
                bw.Write(Views.Value);

        }
    }
}
