using System.IO;

namespace TeleNet.Models.TL
{
	[TLObject(1471006352)]
    public class TLPhoneCallDiscardReasonHangup : TLAbsPhoneCallDiscardReason
    {
        public override int Constructor
        {
            get
            {
                return 1471006352;
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
