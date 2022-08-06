using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL133.Messages
{
	[TLObject(1937010524)]
    public class TLRequestGetExportedChatInvite : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return 1937010524;
            }
        }

                public TLAbsInputPeer Peer {get;set;}
        public string Link {get;set;}
public Messages.TLAbsExportedChatInvite Response { get; set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Peer = (TLAbsInputPeer)ObjectUtils.DeserializeObject(br);
Link = StringUtil.Deserialize(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            ObjectUtils.SerializeObject(Peer,bw);
StringUtil.Serialize(Link,bw);

        }

		public override void DeserializeResponse(BinaryReader br)
		{
			Response = (Messages.TLAbsExportedChatInvite)ObjectUtils.DeserializeObject(br);

		}
    }
}
