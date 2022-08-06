using System.IO;

namespace TeleNet.Models.TL
{
	[TLObject(-1596951477)]
    public class TLSecureValueTypeIdentityCard : TLAbsSecureValueType
    {
        public override int Constructor
        {
            get
            {
                return -1596951477;
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
