using TeleNet.Models.TL;
using System.IO;

namespace  TeleNet.Models.TL85.Auth
{
    [TLObject(-779399914)]
    public class TLRequestCheckPassword : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return -779399914;
            }
        }

        public TLAbsInputCheckPasswordSRP Password { get; set; }
        public TeleNet.Models.TL.Auth.TLAbsAuthorization Response { get; set; }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Password = (TLAbsInputCheckPasswordSRP)ObjectUtils.DeserializeObject(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ObjectUtils.SerializeObject(Password, bw);

        }

        public override void DeserializeResponse(BinaryReader br)
        {
            Response = (TL.Auth.TLAbsAuthorization)ObjectUtils.DeserializeObject(br);

        }
    }
}
