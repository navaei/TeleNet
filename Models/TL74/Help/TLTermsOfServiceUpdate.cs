using System.IO;

namespace TeleNet.Models.TL.Help
{
	[TLObject(686618977)]
    public class TLTermsOfServiceUpdate : TLAbsTermsOfServiceUpdate
    {
        public override int Constructor
        {
            get
            {
                return 686618977;
            }
        }

             public int Expires {get;set;}
     public Help.TLTermsOfService TermsOfService {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Expires = br.ReadInt32();
TermsOfService = (Help.TLTermsOfService)ObjectUtils.DeserializeObject(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            bw.Write(Expires);
ObjectUtils.SerializeObject(TermsOfService,bw);

        }
    }
}
