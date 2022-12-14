using System.IO;

namespace TeleNet.Models.TL.Messages
{
	[TLObject(546656559)]
    public class TLRequestSendMultiMedia : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return 546656559;
            }
        }

                public int Flags {get;set;}
        public bool Silent {get;set;}
        public bool Background {get;set;}
        public bool ClearDraft {get;set;}
        public TLAbsInputPeer Peer {get;set;}
        public int? ReplyToMsgId {get;set;}
        public TLVector<TLInputSingleMedia> MultiMedia {get;set;}
        public TLAbsUpdates Response{ get; set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
Silent = (Flags & 32) != 0;
Background = (Flags & 64) != 0;
ClearDraft = (Flags & 128) != 0;
Peer = (TLAbsInputPeer)ObjectUtils.DeserializeObject(br);
if ((Flags & 1) != 0)
ReplyToMsgId = br.ReadInt32();
else
ReplyToMsgId = null;

MultiMedia = (TLVector<TLInputSingleMedia>)ObjectUtils.DeserializeVector<TLInputSingleMedia>(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            bw.Write(Flags);



ObjectUtils.SerializeObject(Peer,bw);
if ((Flags & 1) != 0)
bw.Write(ReplyToMsgId.Value);
ObjectUtils.SerializeObject(MultiMedia,bw);

        }
		public override void DeserializeResponse(BinaryReader br)
		{
			Response = (TLAbsUpdates)ObjectUtils.DeserializeObject(br);

		}
    }
}
