using System.IO;

namespace TeleNet.Models.TL
{
	[TLObject(-874308058)]
    public class TLSecureValueTypeAddress : TLAbsSecureValueType
    {
        public override int Constructor
        {
            get
            {
                return -874308058;
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
