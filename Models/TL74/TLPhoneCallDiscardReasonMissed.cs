using System.IO;

namespace TeleNet.Models.TL
{
	[TLObject(-2048646399)]
    public class TLPhoneCallDiscardReasonMissed : TLAbsPhoneCallDiscardReason
    {
        public override int Constructor
        {
            get
            {
                return -2048646399;
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
