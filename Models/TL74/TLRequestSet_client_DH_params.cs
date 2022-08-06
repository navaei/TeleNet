using System.IO;
using BigMath;

namespace TeleNet.Models.TL
{
	[TLObject(-184262881)]
    public class TLRequestSet_client_DH_params : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return -184262881;
            }
        }

                public Int128 Nonce {get;set;}
        public Int128 ServerNonce {get;set;}
        public string EncryptedData {get;set;}
        public TLAbsSet_client_DH_params_answer Response{ get; set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Nonce = (Int128)ObjectUtils.DeserializeObject(br);
ServerNonce = (Int128)ObjectUtils.DeserializeObject(br);
EncryptedData = StringUtil.Deserialize(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            ObjectUtils.SerializeObject(Nonce,bw);
ObjectUtils.SerializeObject(ServerNonce,bw);
StringUtil.Serialize(EncryptedData,bw);

        }
		public override void DeserializeResponse(BinaryReader br)
		{
			Response = (TLAbsSet_client_DH_params_answer)ObjectUtils.DeserializeObject(br);

		}
    }
}
