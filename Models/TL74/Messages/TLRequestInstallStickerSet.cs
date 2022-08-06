using System.IO;
using TeleNet.Models.TL.Messages;

namespace TeleNet.Models.TL.Messages
{
    [TLObject(-946871200)]
    public class TLRequestInstallStickerSet : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return -946871200;
            }
        }

        public TLAbsInputStickerSet Stickerset { get; set; }
        public bool Archived { get; set; }
        public TLAbsStickerSetInstallResult Response { get; set; }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Stickerset = (TLAbsInputStickerSet)ObjectUtils.DeserializeObject(br);
            Archived = BoolUtil.Deserialize(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ObjectUtils.SerializeObject(Stickerset, bw);
            BoolUtil.Serialize(Archived, bw);

        }
        public override void DeserializeResponse(BinaryReader br)
        {
            Response = (TLAbsStickerSetInstallResult)ObjectUtils.DeserializeObject(br);

        }
    }
}
