using System.IO;

namespace TeleNet.Models.TL.Help
{
	[TLObject(-483352705)]
    public class TLTermsOfServiceUpdateEmpty : TLAbsTermsOfServiceUpdate
    {
        public override int Constructor
        {
            get
            {
                return -483352705;
            }
        }

             public int Expires {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Expires = br.ReadInt32();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            bw.Write(Expires);

        }
    }
}
