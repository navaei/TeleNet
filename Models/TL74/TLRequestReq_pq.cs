using System.IO;
using BigMath;

namespace TeleNet.Models.TL
{
	[TLObject(1615239032)]
    public class TLRequestReq_pq : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return 1615239032;
            }
        }

                public Int128 Nonce {get;set;}
        public TLResPQ Response{ get; set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Nonce = (Int128)ObjectUtils.DeserializeObject(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            ObjectUtils.SerializeObject(Nonce,bw);

        }
		public override void DeserializeResponse(BinaryReader br)
		{
			Response = (TLResPQ)ObjectUtils.DeserializeObject(br);

		}
    }
}
