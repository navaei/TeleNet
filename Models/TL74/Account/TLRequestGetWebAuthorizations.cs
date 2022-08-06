using System.IO;

namespace TeleNet.Models.TL.Account
{
	[TLObject(405695855)]
    public class TLRequestGetWebAuthorizations : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return 405695855;
            }
        }

                public Account.TLWebAuthorizations Response{ get; set;}


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
			Response = (Account.TLWebAuthorizations)ObjectUtils.DeserializeObject(br);

		}
    }
}
