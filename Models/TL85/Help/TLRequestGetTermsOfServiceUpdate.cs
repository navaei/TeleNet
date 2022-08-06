using System.IO;

namespace  TeleNet.Models.TL85.Help
{
	[TLObject(749019089)]
    public class TLRequestGetTermsOfServiceUpdate : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return 749019089;
            }
        }

        public Help.TLAbsTermsOfServiceUpdate Response { get; set;}


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
			Response = (Help.TLAbsTermsOfServiceUpdate)ObjectUtils.DeserializeObject(br);

		}
    }
}
