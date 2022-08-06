using System.IO;
using BigMath;

namespace TeleNet.Models.TL
{
	[TLObject(1003222836)]
    public class TLDh_gen_ok : TLAbsSet_client_DH_params_answer
    {
        public override int Constructor
        {
            get
            {
                return 1003222836;
            }
        }

             public Int128 Nonce {get;set;}
     public Int128 ServerNonce {get;set;}
     public Int128 NewNonceHash1 {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Nonce = (Int128)ObjectUtils.DeserializeObject(br);
ServerNonce = (Int128)ObjectUtils.DeserializeObject(br);
NewNonceHash1 = (Int128)ObjectUtils.DeserializeObject(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            ObjectUtils.SerializeObject(Nonce,bw);
ObjectUtils.SerializeObject(ServerNonce,bw);
ObjectUtils.SerializeObject(NewNonceHash1,bw);

        }
    }
}
