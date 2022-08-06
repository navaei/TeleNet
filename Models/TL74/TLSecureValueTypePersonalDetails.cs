using System.IO;

namespace TeleNet.Models.TL
{
	[TLObject(-1658158621)]
    public class TLSecureValueTypePersonalDetails : TLAbsSecureValueType
    {
        public override int Constructor
        {
            get
            {
                return -1658158621;
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
