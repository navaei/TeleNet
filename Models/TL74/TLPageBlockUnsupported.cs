using System.IO;

namespace TeleNet.Models.TL
{
	[TLObject(324435594)]
    public class TLPageBlockUnsupported : TLAbsPageBlock
    {
        public override int Constructor
        {
            get
            {
                return 324435594;
            }
        }

        

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
    }
}
