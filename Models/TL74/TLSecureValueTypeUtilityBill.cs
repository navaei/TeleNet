using System.IO;

namespace TeleNet.Models.TL
{
	[TLObject(-63531698)]
    public class TLSecureValueTypeUtilityBill : TLAbsSecureValueType
    {
        public override int Constructor
        {
            get
            {
                return -63531698;
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
