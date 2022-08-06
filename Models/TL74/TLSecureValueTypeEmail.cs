using System.IO;

namespace TeleNet.Models.TL
{
	[TLObject(-1908627474)]
    public class TLSecureValueTypeEmail : TLAbsSecureValueType
    {
        public override int Constructor
        {
            get
            {
                return -1908627474;
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
