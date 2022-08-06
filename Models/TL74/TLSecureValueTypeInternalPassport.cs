using System.IO;

namespace TeleNet.Models.TL
{
	[TLObject(-1717268701)]
    public class TLSecureValueTypeInternalPassport : TLAbsSecureValueType
    {
        public override int Constructor
        {
            get
            {
                return -1717268701;
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
