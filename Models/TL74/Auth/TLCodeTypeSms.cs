using System.IO;
using TeleNet.Models.TL.Auth;

namespace TeleNet.Models.TL.Auth
{
    [TLObject(1923290508)]
    public class TLCodeTypeSms : TLAbsCodeType
    {
        public override int Constructor
        {
            get
            {
                return 1923290508;
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
