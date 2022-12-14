using System.IO;

namespace TeleNet.Models.TL.Messages
{
    [TLObject(-110209570)]
    public class TLRequestUninstallStickerSet : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return -110209570;
            }
        }

        public TLAbsInputStickerSet Stickerset { get; set; }
        public bool Response { get; set; }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Stickerset = (TLAbsInputStickerSet)ObjectUtils.DeserializeObject(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ObjectUtils.SerializeObject(Stickerset, bw);

        }
        public override void DeserializeResponse(BinaryReader br)
        {
            Response = BoolUtil.Deserialize(br);

        }
    }
}
