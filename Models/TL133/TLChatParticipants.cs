using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL133
{
	[TLObject(1018991608)]
    public class TLChatParticipants : TLAbsChatParticipants
    {
        public override int Constructor
        {
            get
            {
                return 1018991608;
            }
        }

             public long ChatId {get;set;}
     public TLVector<TLAbsChatParticipant> Participants {get;set;}
     public int Version {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            ChatId = br.ReadInt64();
Participants = (TLVector<TLAbsChatParticipant>)ObjectUtils.DeserializeVector<TLAbsChatParticipant>(br);
Version = br.ReadInt32();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            bw.Write(ChatId);
ObjectUtils.SerializeObject(Participants,bw);
bw.Write(Version);

        }
    }
}
