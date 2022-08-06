using TeleNet.Models.TL;
using System.IO;

namespace  TeleNet.Models.TL85
{
	[TLObject(-1736378792)]
    public class TLInputCheckPasswordEmpty : TLAbsInputCheckPasswordSRP
    {
        public override int Constructor
        {
            get
            {
                return -1736378792;
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
