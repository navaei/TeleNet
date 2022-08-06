using System.IO;

namespace TeleNet.Models.TL
{
	[TLObject(1034709504)]
    public class TLSecureValueTypePassport : TLAbsSecureValueType
    {
        public override int Constructor
        {
            get
            {
                return 1034709504;
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
