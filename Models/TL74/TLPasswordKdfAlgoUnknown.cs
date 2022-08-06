using System.IO;

namespace TeleNet.Models.TL
{
	[TLObject(-732254058)]
    public class TLPasswordKdfAlgoUnknown : TLAbsPasswordKdfAlgo
    {
        public override int Constructor
        {
            get
            {
                return -732254058;
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
