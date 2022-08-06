using System.IO;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL123
{
    [TLObject(678405636)]
    public class TLMessageService : TLAbsMessage
    {
        public override int Constructor
        {
            get
            {
                return 678405636;
            }
        }

        
        public TLAbsPeer ToId { get; set; }

       
       
        public bool Legacy { get; set; }
        public TLAbsPeer PeerId { get; set; }
 
        public TLAbsMessageAction Action { get; set; }

        public void ComputeFlags()
        {
            Flags = 0;
            Flags = Out ? (Flags | 2) : (Flags & ~2);
            Flags = Mentioned ? (Flags | 16) : (Flags & ~16);
            Flags = MediaUnread ? (Flags | 32) : (Flags & ~32);
            Flags = Silent ? (Flags | 8192) : (Flags & ~8192);
            Flags = Post ? (Flags | 16384) : (Flags & ~16384);
            Flags = Legacy ? (Flags | 524288) : (Flags & ~524288);
            Flags = FromId != null ? (Flags | 256) : (Flags & ~256);
            Flags = ReplyTo != null ? (Flags | 8) : (Flags & ~8);
        }

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
            Out = (Flags & 2) != 0;
            Mentioned = (Flags & 16) != 0;
            MediaUnread = (Flags & 32) != 0;
            Silent = (Flags & 8192) != 0;
            Post = (Flags & 16384) != 0;
            Legacy = (Flags & 524288) != 0;
            Id = br.ReadInt32();
            if ((Flags & 256) != 0)
                FromId = (TLAbsPeer)ObjectUtils.DeserializeObject(br);
            else
                FromId = null;

            PeerId = (TLAbsPeer)ObjectUtils.DeserializeObject(br);
            if ((Flags & 8) != 0)
                ReplyTo = (TLMessageReplyHeader)ObjectUtils.DeserializeObject(br);
            else
                ReplyTo = null;

            Date = br.ReadInt32();
            Action = (TLAbsMessageAction)ObjectUtils.DeserializeObject(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ComputeFlags();
            bw.Write(Flags);

            bw.Write(Id);
            if ((Flags & 256) != 0)
                ObjectUtils.SerializeObject(FromId, bw);
            ObjectUtils.SerializeObject(PeerId, bw);
            if ((Flags & 8) != 0)
                ObjectUtils.SerializeObject(ReplyTo, bw);
            bw.Write(Date);
            ObjectUtils.SerializeObject(Action, bw);

        }
    }
}
