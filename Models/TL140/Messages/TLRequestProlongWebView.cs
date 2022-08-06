using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL140.Messages
{
	[TLObject(-768945848)]
    public class TLRequestProlongWebView : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return -768945848;
            }
        }

                public int Flags {get;set;}
        public bool Silent {get;set;}
        public TLAbsInputPeer Peer {get;set;}
        public TLAbsInputUser Bot {get;set;}
        public long QueryId {get;set;}
        public int? ReplyToMsgId {get;set;}
public bool Response { get; set;}


		public void ComputeFlags()
		{
			Flags = 0;
Flags = Silent ? (Flags | 32) : (Flags & ~32);
Flags = ReplyToMsgId != null ? (Flags | 1) : (Flags & ~1);

		}

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
Silent = (Flags & 32) != 0;
Peer = (TLAbsInputPeer)ObjectUtils.DeserializeObject(br);
Bot = (TLAbsInputUser)ObjectUtils.DeserializeObject(br);
QueryId = br.ReadInt64();
if ((Flags & 1) != 0)
ReplyToMsgId = br.ReadInt32();
else
ReplyToMsgId = null;


        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            ComputeFlags();
bw.Write(Flags);

ObjectUtils.SerializeObject(Peer,bw);
ObjectUtils.SerializeObject(Bot,bw);
bw.Write(QueryId);
if ((Flags & 1) != 0)
bw.Write(ReplyToMsgId.Value);

        }

		public override void DeserializeResponse(BinaryReader br)
		{
			Response = BoolUtil.Deserialize(br);

		}
    }
}
