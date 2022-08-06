using TeleNet.Models.TL;
using System.IO;

namespace TeleNet.Models.TL99
{

    [TLObject(-797637467)]
    public class TLPhoto : TLAbsPhoto
    {
        public override int Constructor
        {
            get
            {
                return -797637467;//---0xd07504a5----
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
            FileReference = BytesUtil.Deserialize(br);
            Date = br.ReadInt32();
            Sizes = (TLVector<TLAbsPhotoSize>)ObjectUtils.DeserializeVector<TLAbsPhotoSize>(br);
            DcId = br.ReadInt32();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ComputeFlags();
            bw.Write(Flags);

            bw.Write(Id);
            bw.Write(AccessHash);
            if (FileReference == null)
                FileReference = new byte[0];
            BytesUtil.Serialize(FileReference, bw);
            bw.Write(Date);
            ObjectUtils.SerializeObject(Sizes, bw);
            bw.Write(DcId);

        }
    }
}
