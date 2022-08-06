using System.IO;

namespace TeleNet.Models.TL
{
	[TLObject(-513517117)]
    public class TLUpdateDialogUnreadMark : TLAbsUpdate
    {
        public override int Constructor
        {
            get
            {
                return -513517117;
            }
        }

             public int Flags {get;set;}
     public bool Unread {get;set;}
     public TLDialogPeer Peer {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
Unread = (Flags & 1) != 0;
Peer = (TLDialogPeer)ObjectUtils.DeserializeObject(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            bw.Write(Flags);

ObjectUtils.SerializeObject(Peer,bw);

        }
    }
}
