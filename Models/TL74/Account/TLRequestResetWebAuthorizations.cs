using System.IO;

namespace TeleNet.Models.TL.Account
{
	[TLObject(1747789204)]
    public class TLRequestResetWebAuthorizations : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return 1747789204;
            }
        }

                public bool Response{ get; set;}


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
			Response = BoolUtil.Deserialize(br);

		}
    }
}
