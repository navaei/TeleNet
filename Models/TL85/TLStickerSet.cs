using TeleNet.Models.TL;
using System.IO;

namespace  TeleNet.Models.TL85
{
    [TLObject(1434820921)]
    public class TLStickerSet : TLAbsStickerSet
    {
        public override int Constructor
        {
            get
            {
                return 1434820921;
            }
        }

        public int? InstalledDate { get; set; }

        public void ComputeFlags()
        {
            Flags = 0;
            Flags = Archived ? (Flags | 2) : (Flags & ~2);
            Flags = Official ? (Flags | 4) : (Flags & ~4);
            Flags = Masks ? (Flags | 8) : (Flags & ~8);
            Flags = InstalledDate != null ? (Flags | 1) : (Flags & ~1);

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
            bw.Write(Count);
            bw.Write(Hash);

        }
    }
}
