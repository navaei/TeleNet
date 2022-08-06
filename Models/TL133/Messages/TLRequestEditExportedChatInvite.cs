using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL133.Messages
{
	[TLObject(48562110)]
    public class TLRequestEditExportedChatInvite : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return 48562110;
            }
        }

                public int Flags {get;set;}
        public bool Revoked {get;set;}
        public TLAbsInputPeer Peer {get;set;}
        public string Link {get;set;}
        public int? ExpireDate {get;set;}
        public int? UsageLimit {get;set;}
public Messages.TLAbsExportedChatInvite Response { get; set;}


		public void ComputeFlags()
		{
			Flags = 0;
Flags = Revoked ? (Flags | 4) : (Flags & ~4);
Flags = ExpireDate != null ? (Flags | 1) : (Flags & ~1);
Flags = UsageLimit != null ? (Flags | 2) : (Flags & ~2);

		}

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
Revoked = (Flags & 4) != 0;
Peer = (TLAbsInputPeer)ObjectUtils.DeserializeObject(br);
Link = StringUtil.Deserialize(br);
if ((Flags & 1) != 0)
ExpireDate = br.ReadInt32();
else
ExpireDate = null;

if ((Flags & 2) != 0)
UsageLimit = br.ReadInt32();
else
UsageLimit = null;


        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            ComputeFlags();
bw.Write(Flags);

ObjectUtils.SerializeObject(Peer,bw);
StringUtil.Serialize(Link,bw);
if ((Flags & 1) != 0)
bw.Write(ExpireDate.Value);
if ((Flags & 2) != 0)
bw.Write(UsageLimit.Value);

        }

		public override void DeserializeResponse(BinaryReader br)
		{
			Response = (Messages.TLAbsExportedChatInvite)ObjectUtils.DeserializeObject(br);

		}
    }
}
