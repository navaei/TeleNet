using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;
using TeleNet.Models.TL123;

namespace TeleNet.Models.TL133
{
    [TLObject(721967202)]
    public class TLMessageService : TLAbsMessageService
    {
        public override int Constructor
        {
            get
            {
                return 721967202;
            }
        }

        public int? TtlPeriod { get; set; }


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
            Flags = TtlPeriod != null ? (Flags | 33554432) : (Flags & ~33554432);

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
            if ((Flags & 33554432) != 0)
                TtlPeriod = br.ReadInt32();
            else
                TtlPeriod = null;
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
            if ((Flags & 33554432) != 0)
                bw.Write(TtlPeriod.Value);

        }
    }
}
