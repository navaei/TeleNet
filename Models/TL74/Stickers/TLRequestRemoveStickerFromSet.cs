using System.IO;

namespace TeleNet.Models.TL.Stickers
{
    [TLObject(69556532)]
    public class TLRequestRemoveStickerFromSet : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return 69556532;
            }
        }

        public TLAbsInputDocument Sticker { get; set; }
        public bool Response { get; set; }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Sticker = (TLAbsInputDocument)ObjectUtils.DeserializeObject(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ObjectUtils.SerializeObject(Sticker, bw);

        }
        public override void DeserializeResponse(BinaryReader br)
        {
            Response = BoolUtil.Deserialize(br);

        }
    }
}
