using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL133
{
	[TLObject(-693004986)]
    public class TLUpdateReadChannelDiscussionInbox : TLAbsUpdate
    {
        public override int Constructor
        {
            get
            {
                return -693004986;
            }
        }

             public int Flags {get;set;}
     public long ChannelId {get;set;}
     public int TopMsgId {get;set;}
     public int ReadMaxId {get;set;}
     public long? BroadcastId {get;set;}
     public int? BroadcastPost {get;set;}


		public void ComputeFlags()
		{
			Flags = 0;
Flags = BroadcastId != null ? (Flags | 1) : (Flags & ~1);
Flags = BroadcastPost != null ? (Flags | 1) : (Flags & ~1);

		}

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
ChannelId = br.ReadInt64();
TopMsgId = br.ReadInt32();
ReadMaxId = br.ReadInt32();
if ((Flags & 1) != 0)
BroadcastId = br.ReadInt64();
else
BroadcastId = null;

if ((Flags & 1) != 0)
BroadcastPost = br.ReadInt32();
else
BroadcastPost = null;


        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            ComputeFlags();
bw.Write(Flags);
bw.Write(ChannelId);
bw.Write(TopMsgId);
bw.Write(ReadMaxId);
if ((Flags & 1) != 0)
bw.Write(BroadcastId.Value);
if ((Flags & 1) != 0)
bw.Write(BroadcastPost.Value);

        }
    }
}
