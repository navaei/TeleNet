using System.IO;

namespace TeleNet.Models.TL
{
	[TLObject(-2037963464)]
    public class TLInputMessagePinned : TLAbsInputMessage
    {
        public override int Constructor
        {
            get
            {
                return -2037963464;
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
