using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL123
{
    
    [TLObject(-82216347)]
    public class TLPhoto : TLAbsPhoto
    {
        public override int Constructor
        {
            get
            {
                return -82216347;
            }
        }

        public void ComputeFlags()
        {
            Flags = 0;
            Flags = HasStickers ? (Flags | 1) : (Flags & ~1);
            Flags = VideoSizes != null ? (Flags | 2) : (Flags & ~2);
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
            if ((Flags & 2) != 0)
                VideoSizes = ObjectUtils.DeserializeVector<TLAbsVideoSize>(br);
            else
                VideoSizes = null;

            DcId = br.ReadInt32();
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
            if ((Flags & 2) != 0)
                ObjectUtils.SerializeObject(VideoSizes, bw);
            bw.Write(DcId);

        }
    }
}
