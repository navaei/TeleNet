using System.IO;

namespace TeleNet.Models.TL.Stickers
{
    [TLObject(-2041315650)]
    public class TLRequestAddStickerToSet : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return -2041315650;
            }
        }

        public TLAbsInputStickerSet Stickerset { get; set; }
        public TLInputStickerSetItem Sticker { get; set; }
        public TLStickerSet Response { get; set; }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Stickerset = (TLAbsInputStickerSet)ObjectUtils.DeserializeObject(br);
            Sticker = (TLInputStickerSetItem)ObjectUtils.DeserializeObject(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ObjectUtils.SerializeObject(Stickerset, bw);
            ObjectUtils.SerializeObject(Sticker, bw);

        }
        public override void DeserializeResponse(BinaryReader br)
        {
            Response = (TLStickerSet)ObjectUtils.DeserializeObject(br);

        }
    }
}
