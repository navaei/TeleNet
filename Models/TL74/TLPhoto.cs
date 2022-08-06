using System.IO;

namespace TeleNet.Models.TL
{
    [TLObject(-1836524247)]
    public class TLPhoto : TLAbsPhoto
    {
        public override int Constructor
        {
            get
            {
                return -1836524247;
            }
        }


        public void ComputeFlags()
        {
            Flags = 0;
            Flags = HasStickers ? (Flags | 1) : (Flags & ~1);

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
            HasStickers = (Flags & 1) != 0;
            Id = br.ReadInt64();
            AccessHash = br.ReadInt64();
            Date = br.ReadInt32();
            Sizes = (TLVector<TLAbsPhotoSize>)ObjectUtils.DeserializeVector<TLAbsPhotoSize>(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ComputeFlags();
            bw.Write(Flags);

            bw.Write(Id);
            bw.Write(AccessHash);
            bw.Write(Date);
            ObjectUtils.SerializeObject(Sizes, bw);

        }
    }
}
