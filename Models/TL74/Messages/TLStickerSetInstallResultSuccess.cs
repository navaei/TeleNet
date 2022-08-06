using System.IO;
using TeleNet.Models.TL.Messages;

namespace TeleNet.Models.TL.Messages
{
    [TLObject(946083368)]
    public class TLStickerSetInstallResultSuccess : TLAbsStickerSetInstallResult
    {
        public override int Constructor
        {
            get
            {
                return 946083368;
            }
        }



        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);

        }
    }
}
