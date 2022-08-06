using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL140.Messages
{
	[TLObject(-528091926)]
    public class TLRequestHideAllChatJoinRequests : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return -528091926;
            }
        }

                public int Flags {get;set;}
        public bool Approved {get;set;}
        public TLAbsInputPeer Peer {get;set;}
        public string Link {get;set;}
public TLAbsUpdates Response { get; set;}


		public void ComputeFlags()
		{
			Flags = 0;
Flags = Approved ? (Flags | 1) : (Flags & ~1);
Flags = Link != null ? (Flags | 2) : (Flags & ~2);

		}

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
Approved = (Flags & 1) != 0;
Peer = (TLAbsInputPeer)ObjectUtils.DeserializeObject(br);
if ((Flags & 2) != 0)
Link = StringUtil.Deserialize(br);
else
Link = null;


        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            ComputeFlags();
bw.Write(Flags);

ObjectUtils.SerializeObject(Peer,bw);
if ((Flags & 2) != 0)
StringUtil.Serialize(Link,bw);

        }

		public override void DeserializeResponse(BinaryReader br)
		{
			Response = (TLAbsUpdates)ObjectUtils.DeserializeObject(br);

		}
    }
}
