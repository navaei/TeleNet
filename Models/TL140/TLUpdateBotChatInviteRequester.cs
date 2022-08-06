using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL140
{
	[TLObject(299870598)]
    public class TLUpdateBotChatInviteRequester : TLAbsUpdate
    {
        public override int Constructor
        {
            get
            {
                return 299870598;
            }
        }

             public TLAbsPeer Peer {get;set;}
     public int Date {get;set;}
     public long UserId {get;set;}
     public string About {get;set;}
     public TLAbsExportedChatInvite Invite {get;set;}
     public int Qts {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Peer = (TLAbsPeer)ObjectUtils.DeserializeObject(br);
Date = br.ReadInt32();
UserId = br.ReadInt64();
About = StringUtil.Deserialize(br);
Invite = (TLAbsExportedChatInvite)ObjectUtils.DeserializeObject(br);
Qts = br.ReadInt32();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            ObjectUtils.SerializeObject(Peer,bw);
bw.Write(Date);
bw.Write(UserId);
StringUtil.Serialize(About,bw);
ObjectUtils.SerializeObject(Invite,bw);
bw.Write(Qts);

        }
    }
}
