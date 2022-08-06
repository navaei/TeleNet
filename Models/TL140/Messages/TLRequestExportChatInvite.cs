using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL140.Messages
{
	[TLObject(-1607670315)]
    public class TLRequestExportChatInvite : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return -1607670315;
            }
        }

                public int Flags {get;set;}
        public bool LegacyRevokePermanent {get;set;}
        public bool RequestNeeded {get;set;}
        public TLAbsInputPeer Peer {get;set;}
        public int? ExpireDate {get;set;}
        public int? UsageLimit {get;set;}
        public string Title {get;set;}
public TLAbsExportedChatInvite Response { get; set;}


		public void ComputeFlags()
		{
			Flags = 0;
Flags = LegacyRevokePermanent ? (Flags | 4) : (Flags & ~4);
Flags = RequestNeeded ? (Flags | 8) : (Flags & ~8);
Flags = ExpireDate != null ? (Flags | 1) : (Flags & ~1);
Flags = UsageLimit != null ? (Flags | 2) : (Flags & ~2);
Flags = Title != null ? (Flags | 16) : (Flags & ~16);

		}

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
LegacyRevokePermanent = (Flags & 4) != 0;
RequestNeeded = (Flags & 8) != 0;
Peer = (TLAbsInputPeer)ObjectUtils.DeserializeObject(br);
if ((Flags & 1) != 0)
ExpireDate = br.ReadInt32();
else
ExpireDate = null;

if ((Flags & 2) != 0)
UsageLimit = br.ReadInt32();
else
UsageLimit = null;

if ((Flags & 16) != 0)
Title = StringUtil.Deserialize(br);
else
Title = null;


        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            ComputeFlags();
bw.Write(Flags);


ObjectUtils.SerializeObject(Peer,bw);
if ((Flags & 1) != 0)
bw.Write(ExpireDate.Value);
if ((Flags & 2) != 0)
bw.Write(UsageLimit.Value);
if ((Flags & 16) != 0)
StringUtil.Serialize(Title,bw);

        }

		public override void DeserializeResponse(BinaryReader br)
		{
			Response = (TLAbsExportedChatInvite)ObjectUtils.DeserializeObject(br);

		}
    }
}
