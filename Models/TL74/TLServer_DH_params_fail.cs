using System.IO;
using BigMath;

namespace TeleNet.Models.TL
{
	[TLObject(2043348061)]
    public class TLServer_DH_params_fail : TLAbsServer_DH_Params
    {
        public override int Constructor
        {
            get
            {
                return 2043348061;
            }
        }

             public Int128 Nonce {get;set;}
     public Int128 ServerNonce {get;set;}
     public Int128 NewNonceHash {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Nonce = (Int128)ObjectUtils.DeserializeObject(br);
ServerNonce = (Int128)ObjectUtils.DeserializeObject(br);
NewNonceHash = (Int128)ObjectUtils.DeserializeObject(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            ObjectUtils.SerializeObject(Nonce,bw);
ObjectUtils.SerializeObject(ServerNonce,bw);
ObjectUtils.SerializeObject(NewNonceHash,bw);

        }
    }
}
