using System.IO;

namespace TeleNet.Models.TL
{
	[TLObject(-1713143702)]
    public class TLSecureValueTypePassportRegistration : TLAbsSecureValueType
    {
        public override int Constructor
        {
            get
            {
                return -1713143702;
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
