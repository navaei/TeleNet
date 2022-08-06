using System.IO;
using TeleNet.Models.TL;

namespace  TeleNet.Models.TL85.Help
{
	[TLObject(737668643)]
    public class TLProxyDataPromo : TLAbsProxyData
    {
        public override int Constructor
        {
            get
            {
                return 737668643;
            }
        }

             public int Expires {get;set;}
     public TLAbsPeer Peer {get;set;}
     public TLVector<TLAbsChat> Chats {get;set;}
     public TLVector<TLAbsUser> Users {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Expires = br.ReadInt32();
Peer = (TLAbsPeer)ObjectUtils.DeserializeObject(br);
Chats = (TLVector<TLAbsChat>)ObjectUtils.DeserializeVector<TLAbsChat>(br);
Users = (TLVector<TLAbsUser>)ObjectUtils.DeserializeVector<TLAbsUser>(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            bw.Write(Expires);
ObjectUtils.SerializeObject(Peer,bw);
ObjectUtils.SerializeObject(Chats,bw);
ObjectUtils.SerializeObject(Users,bw);

        }
    }
}
