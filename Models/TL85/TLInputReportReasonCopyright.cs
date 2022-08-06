using System.IO;

namespace  TeleNet.Models.TL85
{
	[TLObject(-1685456582)]
    public class TLInputReportReasonCopyright : TLObject
    {
        public override int Constructor
        {
            get
            {
                return -1685456582;
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
