using System.IO;

namespace TeleNet.Models.TL
{
	[TLObject(-530392189)]
    public class TLInputMessagesFilterContacts : TLAbsMessagesFilter
    {
        public override int Constructor
        {
            get
            {
                return -530392189;
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
