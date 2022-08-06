using System.IO;

namespace TeleNet.Models.TL
{
    [TLObject(1753886890)]
    public class TLUpdateNewStickerSet : TLAbsUpdate
    {
        public override int Constructor
        {
            get
            {
                return 1753886890;
            }
        }

        public TLStickerSet Stickerset { get; set; }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Stickerset = (TLStickerSet)ObjectUtils.DeserializeObject(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ObjectUtils.SerializeObject(Stickerset, bw);

        }
    }
}
