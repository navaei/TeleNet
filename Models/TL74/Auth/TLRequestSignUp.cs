using System.IO;

namespace TeleNet.Models.TL.Auth
{
    [TLObject(453408308)]
    public class TLRequestSignUp : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return 453408308;
            }
        }

        public string PhoneNumber { get; set; }
        public string PhoneCodeHash { get; set; }
        public string PhoneCode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Auth.TLAbsAuthorization Response { get; set; }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            PhoneNumber = StringUtil.Deserialize(br);
            PhoneCodeHash = StringUtil.Deserialize(br);
            PhoneCode = StringUtil.Deserialize(br);
            FirstName = StringUtil.Deserialize(br);
            LastName = StringUtil.Deserialize(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            StringUtil.Serialize(PhoneNumber, bw);
            StringUtil.Serialize(PhoneCodeHash, bw);
            StringUtil.Serialize(PhoneCode, bw);
            StringUtil.Serialize(FirstName, bw);
            StringUtil.Serialize(LastName, bw);

        }
        public override void DeserializeResponse(BinaryReader br)
        {
            Response = (Auth.TLAbsAuthorization)ObjectUtils.DeserializeObject(br);

        }
    }
}
