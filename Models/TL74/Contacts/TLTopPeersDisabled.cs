using System.IO;

namespace TeleNet.Models.TL.Contacts
{
	[TLObject(-1255369827)]
    public class TLTopPeersDisabled : TLAbsTopPeers
    {
        public override int Constructor
        {
            get
            {
                return -1255369827;
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
