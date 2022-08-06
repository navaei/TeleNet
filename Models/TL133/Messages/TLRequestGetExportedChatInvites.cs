using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL133.Messages
{
	[TLObject(-1565154314)]
    public class TLRequestGetExportedChatInvites : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return -1565154314;
            }
        }

                public int Flags {get;set;}
        public bool Revoked {get;set;}
        public TLAbsInputPeer Peer {get;set;}
        public TLAbsInputUser AdminId {get;set;}
        public int? OffsetDate {get;set;}
        public string OffsetLink {get;set;}
        public int Limit {get;set;}
public Messages.TLExportedChatInvites Response { get; set;}


		public void ComputeFlags()
		{
			Flags = 0;
Flags = Revoked ? (Flags | 8) : (Flags & ~8);
Flags = OffsetDate != null ? (Flags | 4) : (Flags & ~4);
Flags = OffsetLink != null ? (Flags | 4) : (Flags & ~4);

		}

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
Revoked = (Flags & 8) != 0;
Peer = (TLAbsInputPeer)ObjectUtils.DeserializeObject(br);
AdminId = (TLAbsInputUser)ObjectUtils.DeserializeObject(br);
if ((Flags & 4) != 0)
OffsetDate = br.ReadInt32();
else
OffsetDate = null;

if ((Flags & 4) != 0)
OffsetLink = StringUtil.Deserialize(br);
else
OffsetLink = null;

Limit = br.ReadInt32();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            ComputeFlags();
bw.Write(Flags);

ObjectUtils.SerializeObject(Peer,bw);
ObjectUtils.SerializeObject(AdminId,bw);
if ((Flags & 4) != 0)
bw.Write(OffsetDate.Value);
if ((Flags & 4) != 0)
StringUtil.Serialize(OffsetLink,bw);
bw.Write(Limit);

        }

		public override void DeserializeResponse(BinaryReader br)
		{
			Response = (Messages.TLExportedChatInvites)ObjectUtils.DeserializeObject(br);

		}
    }
}
