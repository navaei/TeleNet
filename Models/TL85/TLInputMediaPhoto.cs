using System.IO;
using TeleNet.Models.TL;

namespace  TeleNet.Models.TL85
{
    [TLObject(-1279654347)]
    public class TLInputMediaPhoto : TLAbsInputMedia
    {
        public override int Constructor
        {
            get
            {
                return -1279654347;
            }
        }

        public int Flags { get; set; }
        public TLAbsInputPhoto Id { get; set; }
        public int? TtlSeconds { get; set; }


        public void ComputeFlags()
        {
            Flags = 0;
            Flags = TtlSeconds != null ? (Flags | 1) : (Flags & ~1);

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
            Id = (TLAbsInputPhoto)ObjectUtils.DeserializeObject(br);
            if ((Flags & 1) != 0)
                TtlSeconds = br.ReadInt32();
            else
                TtlSeconds = null;


        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ComputeFlags();
            bw.Write(Flags);
            ObjectUtils.SerializeObject(Id, bw);
            if ((Flags & 1) != 0)
                bw.Write(TtlSeconds.Value);

        }
    }
}
