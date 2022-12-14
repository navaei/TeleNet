using System.IO;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL85
{
    [TLObject(-1673036328)]
    public class TLPhoto : TLObject
    {
        public override int Constructor
        {
            get
            {
                return -1673036328;
            }
        }

        public int Flags { get; set; }
        public bool HasStickers { get; set; }
        public long Id { get; set; }
        public long AccessHash { get; set; }
        public byte[] FileReference { get; set; }
        public int Date { get; set; }
        public TLVector<TLAbsPhotoSize> Sizes { get; set; }


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
            FileReference = BytesUtil.Deserialize(br);
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
            BytesUtil.Serialize(FileReference, bw);
            bw.Write(Date);
            ObjectUtils.SerializeObject(Sizes, bw);

        }
    }
}
