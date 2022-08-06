using System.IO;

namespace TeleNet.Models.TL
{
	[TLObject(-419271411)]
    public class TLInputMessagesFilterGeo : TLAbsMessagesFilter
    {
        public override int Constructor
        {
            get
            {
                return -419271411;
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
