using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL140.Messages
{
	[TLObject(834488621)]
    public class TLMessageReactionsList : TLObject
    {
        public override int Constructor
        {
            get
            {
                return 834488621;
            }
        }

             public int Flags {get;set;}
     public int Count {get;set;}
     public TLVector<TLMessagePeerReaction> Reactions {get;set;}
     public TLVector<TLAbsChat> Chats {get;set;}
     public TLVector<TLAbsUser> Users {get;set;}
     public string NextOffset {get;set;}


		public void ComputeFlags()
		{
			Flags = 0;
Flags = NextOffset != null ? (Flags | 1) : (Flags & ~1);

		}

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
Count = br.ReadInt32();
Reactions = (TLVector<TLMessagePeerReaction>)ObjectUtils.DeserializeVector<TLMessagePeerReaction>(br);
Chats = (TLVector<TLAbsChat>)ObjectUtils.DeserializeVector<TLAbsChat>(br);
Users = (TLVector<TLAbsUser>)ObjectUtils.DeserializeVector<TLAbsUser>(br);
if ((Flags & 1) != 0)
NextOffset = StringUtil.Deserialize(br);
else
NextOffset = null;


        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            ComputeFlags();
bw.Write(Flags);
bw.Write(Count);
ObjectUtils.SerializeObject(Reactions,bw);
ObjectUtils.SerializeObject(Chats,bw);
ObjectUtils.SerializeObject(Users,bw);
if ((Flags & 1) != 0)
StringUtil.Serialize(NextOffset,bw);

        }
    }
}
