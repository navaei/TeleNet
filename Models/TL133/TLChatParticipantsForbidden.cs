using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL133
{
	[TLObject(-2023500831)]
    public class TLChatParticipantsForbidden : TLAbsChatParticipants
    {
        public override int Constructor
        {
            get
            {
                return -2023500831;
            }
        }

             public int Flags {get;set;}
     public long ChatId {get;set;}
     public TLAbsChatParticipant SelfParticipant {get;set;}


		public void ComputeFlags()
		{
			Flags = 0;
Flags = SelfParticipant != null ? (Flags | 1) : (Flags & ~1);

		}

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
ChatId = br.ReadInt64();
if ((Flags & 1) != 0)
SelfParticipant = (TLAbsChatParticipant)ObjectUtils.DeserializeObject(br);
else
SelfParticipant = null;


        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            ComputeFlags();
bw.Write(Flags);
bw.Write(ChatId);
if ((Flags & 1) != 0)
ObjectUtils.SerializeObject(SelfParticipant,bw);

        }
    }
}
