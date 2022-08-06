using System.IO;
using BigMath;

namespace TeleNet.Models.TL
{
	[TLObject(-790100132)]
    public class TLServer_DH_params_ok : TLAbsServer_DH_Params
    {
        public override int Constructor
        {
            get
            {
                return -790100132;
            }
        }

             public Int128 Nonce {get;set;}
     public Int128 ServerNonce {get;set;}
     public string EncryptedAnswer {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Nonce = (Int128)ObjectUtils.DeserializeObject(br);
ServerNonce = (Int128)ObjectUtils.DeserializeObject(br);
EncryptedAnswer = StringUtil.Deserialize(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            ObjectUtils.SerializeObject(Nonce,bw);
ObjectUtils.SerializeObject(ServerNonce,bw);
StringUtil.Serialize(EncryptedAnswer,bw);

        }
    }
}
