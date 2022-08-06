using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL140.Messages
{
	[TLObject(-521245833)]
    public class TLRequestGetMessageReactionsList : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return -521245833;
            }
        }

                public int Flags {get;set;}
        public TLAbsInputPeer Peer {get;set;}
        public int Id {get;set;}
        public string Reaction {get;set;}
        public string Offset {get;set;}
        public int Limit {get;set;}
public Messages.TLMessageReactionsList Response { get; set;}


		public void ComputeFlags()
		{
			Flags = 0;
Flags = Reaction != null ? (Flags | 1) : (Flags & ~1);
Flags = Offset != null ? (Flags | 2) : (Flags & ~2);

		}

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
Peer = (TLAbsInputPeer)ObjectUtils.DeserializeObject(br);
Id = br.ReadInt32();
if ((Flags & 1) != 0)
Reaction = StringUtil.Deserialize(br);
else
Reaction = null;

if ((Flags & 2) != 0)
Offset = StringUtil.Deserialize(br);
else
Offset = null;

Limit = br.ReadInt32();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            ComputeFlags();
bw.Write(Flags);
ObjectUtils.SerializeObject(Peer,bw);
bw.Write(Id);
if ((Flags & 1) != 0)
StringUtil.Serialize(Reaction,bw);
if ((Flags & 2) != 0)
StringUtil.Serialize(Offset,bw);
bw.Write(Limit);

        }

		public override void DeserializeResponse(BinaryReader br)
		{
			Response = (Messages.TLMessageReactionsList)ObjectUtils.DeserializeObject(br);

		}
    }
}
