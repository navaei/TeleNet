using System.IO;
using TeleNet.Models.TL;

namespace  TeleNet.Models.TL85
{
	[TLObject(-55902537)]
    public class TLInputDialogPeer : TLAbsInputDialogPeer
    {
        public override int Constructor
        {
            get
            {
                return -55902537;
            }
        }

             public TLAbsInputPeer Peer {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Peer = (TLAbsInputPeer)ObjectUtils.DeserializeObject(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            ObjectUtils.SerializeObject(Peer,bw);

        }
    }
}
