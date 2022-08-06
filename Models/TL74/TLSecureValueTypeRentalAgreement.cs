using System.IO;

namespace TeleNet.Models.TL
{
	[TLObject(-1954007928)]
    public class TLSecureValueTypeRentalAgreement : TLAbsSecureValueType
    {
        public override int Constructor
        {
            get
            {
                return -1954007928;
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
