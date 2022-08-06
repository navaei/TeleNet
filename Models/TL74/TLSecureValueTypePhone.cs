using System.IO;

namespace TeleNet.Models.TL
{
	[TLObject(-1289704741)]
    public class TLSecureValueTypePhone : TLAbsSecureValueType
    {
        public override int Constructor
        {
            get
            {
                return -1289704741;
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
