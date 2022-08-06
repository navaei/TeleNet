using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL140.Channels
{
	[TLObject(-2091463255)]
    public class TLSendAsPeers : TLObject
    {
        public override int Constructor
        {
            get
            {
                return -2091463255;
            }
        }

             public TLVector<TLAbsPeer> Peers {get;set;}
     public TLVector<TLAbsChat> Chats {get;set;}
     public TLVector<TLAbsUser> Users {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Peers = (TLVector<TLAbsPeer>)ObjectUtils.DeserializeVector<TLAbsPeer>(br);
Chats = (TLVector<TLAbsChat>)ObjectUtils.DeserializeVector<TLAbsChat>(br);
Users = (TLVector<TLAbsUser>)ObjectUtils.DeserializeVector<TLAbsUser>(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            ObjectUtils.SerializeObject(Peers,bw);
ObjectUtils.SerializeObject(Chats,bw);
ObjectUtils.SerializeObject(Users,bw);

        }
    }
}
