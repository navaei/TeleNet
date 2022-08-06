using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL140.Messages
{
	[TLObject(-134016113)]
    public class TLRequestSendMultiMedia : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return -134016113;
            }
        }

                public int Flags {get;set;}
        public bool Silent {get;set;}
        public bool Background {get;set;}
        public bool ClearDraft {get;set;}
        public bool Noforwards {get;set;}
        public TLAbsInputPeer Peer {get;set;}
        public int? ReplyToMsgId {get;set;}
        public TLVector<TLInputSingleMedia> MultiMedia {get;set;}
        public int? ScheduleDate {get;set;}
        public TLAbsInputPeer SendAs {get;set;}
public TLAbsUpdates Response { get; set;}


		public void ComputeFlags()
		{
			Flags = 0;
Flags = Silent ? (Flags | 32) : (Flags & ~32);
Flags = Background ? (Flags | 64) : (Flags & ~64);
Flags = ClearDraft ? (Flags | 128) : (Flags & ~128);
Flags = Noforwards ? (Flags | 16384) : (Flags & ~16384);
Flags = ReplyToMsgId != null ? (Flags | 1) : (Flags & ~1);
Flags = ScheduleDate != null ? (Flags | 1024) : (Flags & ~1024);
Flags = SendAs != null ? (Flags | 8192) : (Flags & ~8192);

		}

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
Silent = (Flags & 32) != 0;
Background = (Flags & 64) != 0;
ClearDraft = (Flags & 128) != 0;
Noforwards = (Flags & 16384) != 0;
Peer = (TLAbsInputPeer)ObjectUtils.DeserializeObject(br);
if ((Flags & 1) != 0)
ReplyToMsgId = br.ReadInt32();
else
ReplyToMsgId = null;

MultiMedia = (TLVector<TLInputSingleMedia>)ObjectUtils.DeserializeVector<TLInputSingleMedia>(br);
if ((Flags & 1024) != 0)
ScheduleDate = br.ReadInt32();
else
ScheduleDate = null;

if ((Flags & 8192) != 0)
SendAs = (TLAbsInputPeer)ObjectUtils.DeserializeObject(br);
else
SendAs = null;


        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            ComputeFlags();
bw.Write(Flags);




ObjectUtils.SerializeObject(Peer,bw);
if ((Flags & 1) != 0)
bw.Write(ReplyToMsgId.Value);
ObjectUtils.SerializeObject(MultiMedia,bw);
if ((Flags & 1024) != 0)
bw.Write(ScheduleDate.Value);
if ((Flags & 8192) != 0)
ObjectUtils.SerializeObject(SendAs,bw);

        }

		public override void DeserializeResponse(BinaryReader br)
		{
			Response = (TLAbsUpdates)ObjectUtils.DeserializeObject(br);

		}
    }
}
