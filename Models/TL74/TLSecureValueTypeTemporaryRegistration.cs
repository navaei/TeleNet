using System.IO;

namespace TeleNet.Models.TL
{
	[TLObject(-368907213)]
    public class TLSecureValueTypeTemporaryRegistration : TLAbsSecureValueType
    {
        public override int Constructor
        {
            get
            {
                return -368907213;
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
