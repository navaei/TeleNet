using System.IO;
using TeleNet.Models.TL.Auth;

namespace TeleNet.Models.TL.Auth
{
    [TLObject(577556219)]
    public class TLCodeTypeFlashCall : TLAbsCodeType
    {
        public override int Constructor
        {
            get
            {
                return 577556219;
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
