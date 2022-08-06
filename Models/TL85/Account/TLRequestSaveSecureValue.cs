using TeleNet.Models.TL;
using System.IO;

namespace TeleNet.Models.TL85.Account
{
    [TLObject(-1986010339)]
    public class TLRequestSaveSecureValue : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return -1986010339;
            }
        }

        public TLInputSecureValue Value { get; set; }
        public long SecureSecretId { get; set; }
        public TLSecureValue Response { get; set; }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Value = (TLInputSecureValue)ObjectUtils.DeserializeObject(br);
            SecureSecretId = br.ReadInt64();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ObjectUtils.SerializeObject(Value, bw);
            bw.Write(SecureSecretId);

        }

        public override void DeserializeResponse(BinaryReader br)
        {
            Response = (TLSecureValue)ObjectUtils.DeserializeObject(br);

        }
    }
}
