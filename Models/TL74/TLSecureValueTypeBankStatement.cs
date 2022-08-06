using System.IO;

namespace TeleNet.Models.TL
{
	[TLObject(-1995211763)]
    public class TLSecureValueTypeBankStatement : TLAbsSecureValueType
    {
        public override int Constructor
        {
            get
            {
                return -1995211763;
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
