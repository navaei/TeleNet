using System.IO;

namespace TeleNet.Models.TL.Auth
{
    [TLObject(1319464594)]
    public class TLRequestRecoverPassword : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return 1319464594;
            }
        }

        public string Code { get; set; }
        public Auth.TLAbsAuthorization Response { get; set; }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Code = StringUtil.Deserialize(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            StringUtil.Serialize(Code, bw);

        }
        public override void DeserializeResponse(BinaryReader br)
        {
            Response = (Auth.TLAbsAuthorization)ObjectUtils.DeserializeObject(br);

        }
    }
}
