using System.IO;

namespace  TeleNet.Models.TL85.Contacts
{
	[TLObject(-1255369827)]
    public class TLTopPeersDisabled : TLObject
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
