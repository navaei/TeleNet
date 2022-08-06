using System.IO;
using TeleNet.Models.TL;

namespace  TeleNet.Models.TL85
{
    [TLObject(-1666158377)]
    public class TLMessageMediaDocument : TLAbsMessageMedia
    {
        public override int Constructor
        {
            get
            {
                return -1666158377;
            }
        }

        public int Flags { get; set; }
        public TLAbsDocument Document { get; set; }
        public int? TtlSeconds { get; set; }


        public void ComputeFlags()
        {
            Flags = 0;
            Flags = Document != null ? (Flags | 1) : (Flags & ~1);
            Flags = TtlSeconds != null ? (Flags | 4) : (Flags & ~4);

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
            if ((Flags & 1) != 0)
                Document = (TLAbsDocument)ObjectUtils.DeserializeObject(br);
            else
                Document = null;

            if ((Flags & 4) != 0)
                TtlSeconds = br.ReadInt32();
            else
                TtlSeconds = null;


        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ComputeFlags();
            bw.Write(Flags);
            if ((Flags & 1) != 0)
                ObjectUtils.SerializeObject(Document, bw);
            if ((Flags & 4) != 0)
                bw.Write(TtlSeconds.Value);

        }
    }
}
