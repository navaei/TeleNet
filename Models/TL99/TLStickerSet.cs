using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL99
{
    [TLObject(-290164953)]
    public class TLStickerSet : TLAbsStickerSet
    {
        public override int Constructor
        {
            get
            {
                return -290164953;
            }
        }

        public int? InstalledDate { get; set; }
        public TLAbsPhotoSize Thumb { get; set; }
        public int? ThumbDcId { get; set; }

        public void ComputeFlags()
        {
            Flags = 0;
            Flags = Archived ? (Flags | 2) : (Flags & ~2);
            Flags = Official ? (Flags | 4) : (Flags & ~4);
            Flags = Masks ? (Flags | 8) : (Flags & ~8);
            Flags = InstalledDate != null ? (Flags | 1) : (Flags & ~1);
            Flags = Thumb != null ? (Flags | 16) : (Flags & ~16);
            Flags = ThumbDcId != null ? (Flags | 16) : (Flags & ~16);

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
            Archived = (Flags & 2) != 0;
            Official = (Flags & 4) != 0;
            Masks = (Flags & 8) != 0;
            if ((Flags & 1) != 0)
                InstalledDate = br.ReadInt32();
            else
                InstalledDate = null;

            Id = br.ReadInt64();
            AccessHash = br.ReadInt64();
            Title = StringUtil.Deserialize(br);
            ShortName = StringUtil.Deserialize(br);
            if ((Flags & 16) != 0)
                Thumb = (TLAbsPhotoSize)ObjectUtils.DeserializeObject(br);
            else
                Thumb = null;

            if ((Flags & 16) != 0)
                ThumbDcId = br.ReadInt32();
            else
                ThumbDcId = null;

            Count = br.ReadInt32();
            Hash = br.ReadInt32();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ComputeFlags();
            bw.Write(Flags);



            if ((Flags & 1) != 0)
                bw.Write(InstalledDate.Value);
            bw.Write(Id);
            bw.Write(AccessHash);
            StringUtil.Serialize(Title, bw);
            StringUtil.Serialize(ShortName, bw);
            if ((Flags & 16) != 0)
                ObjectUtils.SerializeObject(Thumb, bw);
            if ((Flags & 16) != 0)
                bw.Write(ThumbDcId.Value);
            bw.Write(Count);
            bw.Write(Hash);

        }
    }
}
