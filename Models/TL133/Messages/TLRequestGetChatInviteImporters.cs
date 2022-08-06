using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL133.Messages
{
	[TLObject(654013065)]
    public class TLRequestGetChatInviteImporters : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return 654013065;
            }
        }

                public TLAbsInputPeer Peer {get;set;}
        public string Link {get;set;}
        public int OffsetDate {get;set;}
        public TLAbsInputUser OffsetUser {get;set;}
        public int Limit {get;set;}
public Messages.TLChatInviteImporters Response { get; set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Peer = (TLAbsInputPeer)ObjectUtils.DeserializeObject(br);
Link = StringUtil.Deserialize(br);
OffsetDate = br.ReadInt32();
OffsetUser = (TLAbsInputUser)ObjectUtils.DeserializeObject(br);
Limit = br.ReadInt32();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            ObjectUtils.SerializeObject(Peer,bw);
StringUtil.Serialize(Link,bw);
bw.Write(OffsetDate);
ObjectUtils.SerializeObject(OffsetUser,bw);
bw.Write(Limit);

        }

		public override void DeserializeResponse(BinaryReader br)
		{
			Response = (Messages.TLChatInviteImporters)ObjectUtils.DeserializeObject(br);

		}
    }
}
