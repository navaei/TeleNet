using System.IO;

namespace TeleNet.Models.TL
{
	[TLObject(4883767)]
    public class TLSecurePasswordKdfAlgoUnknown : TLAbsSecurePasswordKdfAlgo
    {
        public override int Constructor
        {
            get
            {
                return 4883767;
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
