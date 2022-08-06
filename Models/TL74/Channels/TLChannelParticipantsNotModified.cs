using System.IO;

namespace TeleNet.Models.TL.Channels
{
	[TLObject(-266911767)]
    public class TLChannelParticipantsNotModified : TLAbsChannelParticipants
    {
        public override int Constructor
        {
            get
            {
                return -266911767;
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
