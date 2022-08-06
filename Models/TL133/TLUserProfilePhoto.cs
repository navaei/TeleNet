using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL133
{
    [TLObject(-2100168954)]
    public class TLUserProfilePhoto : TLAbsUserProfilePhoto
    {
        public override int Constructor
        {
            get
            {
                return -2100168954;
            }
        }

        public int Flags { get; set; }
        public bool HasVideo { get; set; }
        public long PhotoId { get; set; }
        public byte[] StrippedThumb { get; set; }
        public int DcId { get; set; }


        public void ComputeFlags()
        {
            Flags = 0;
            Flags = HasVideo ? (Flags | 1) : (Flags & ~1);
            Flags = StrippedThumb != null ? (Flags | 2) : (Flags & ~2);

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
            HasVideo = (Flags & 1) != 0;
            PhotoId = br.ReadInt64();
            if ((Flags & 2) != 0)
                StrippedThumb = BytesUtil.Deserialize(br);
            else
                StrippedThumb = null;

            DcId = br.ReadInt32();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ComputeFlags();
            bw.Write(Flags);

            bw.Write(PhotoId);
            if ((Flags & 2) != 0)
                BytesUtil.Serialize(StrippedThumb, bw);
            bw.Write(DcId);

        }
    }
}
