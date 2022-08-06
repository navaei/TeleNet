using TeleNet.Models.TL;
using System.IO;

namespace  TeleNet.Models.TL85.Account
{
	[TLObject(-1299661699)]
    public class TLRequestGetAllSecureValues : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return -1299661699;
            }
        }

        public TLVector<TLSecureValue> Response { get; set;}


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

		public override void DeserializeResponse(BinaryReader br)
		{
			Response = (TLVector<TLSecureValue>)ObjectUtils.DeserializeVector<TLSecureValue>(br);

		}
    }
}
