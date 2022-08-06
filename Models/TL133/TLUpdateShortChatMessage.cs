using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL133
{
    [TLObject(1299050149)]
    public class TLUpdateShortChatMessage : TLAbsUpdates
    {
        public override int Constructor
        {
            get
            {
                return 1299050149;
            }
        }

        public int Flags { get; set; }
        public bool Out { get; set; }
        public bool Mentioned { get; set; }
        public bool MediaUnread { get; set; }
        public bool Silent { get; set; }
        public int Id { get; set; }
        public long FromId { get; set; }
        public long ChatId { get; set; }
        public string Message { get; set; }
        public int Pts { get; set; }
        public int PtsCount { get; set; }
        public int Date { get; set; }
        public TLAbsMessageFwdHeader FwdFrom { get; set; }
        public long? ViaBotId { get; set; }
        public TL123.TLMessageReplyHeader ReplyTo { get; set; }
        public TLVector<TLAbsMessageEntity> Entities { get; set; }
        public int? TtlPeriod { get; set; }


        public void ComputeFlags()
        {
            Flags = 0;
            Flags = Out ? (Flags | 2) : (Flags & ~2);
            Flags = Mentioned ? (Flags | 16) : (Flags & ~16);
            Flags = MediaUnread ? (Flags | 32) : (Flags & ~32);
            Flags = Silent ? (Flags | 8192) : (Flags & ~8192);
            Flags = FwdFrom != null ? (Flags | 4) : (Flags & ~4);
            Flags = ViaBotId != null ? (Flags | 2048) : (Flags & ~2048);
            Flags = ReplyTo != null ? (Flags | 8) : (Flags & ~8);
            Flags = Entities != null ? (Flags | 128) : (Flags & ~128);
            Flags = TtlPeriod != null ? (Flags | 33554432) : (Flags & ~33554432);

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
            Out = (Flags & 2) != 0;
            Mentioned = (Flags & 16) != 0;
            MediaUnread = (Flags & 32) != 0;
            Silent = (Flags & 8192) != 0;
            Id = br.ReadInt32();
            FromId = br.ReadInt64();
            ChatId = br.ReadInt64();
            Message = StringUtil.Deserialize(br);
            Pts = br.ReadInt32();
            PtsCount = br.ReadInt32();
            Date = br.ReadInt32();
            if ((Flags & 4) != 0)
                FwdFrom = (TLAbsMessageFwdHeader)ObjectUtils.DeserializeObject(br);
            else
                FwdFrom = null;

            if ((Flags & 2048) != 0)
                ViaBotId = br.ReadInt64();
            else
                ViaBotId = null;

            if ((Flags & 8) != 0)
                ReplyTo = (TL123.TLMessageReplyHeader)ObjectUtils.DeserializeObject(br);
            else
                ReplyTo = null;

            if ((Flags & 128) != 0)
                Entities = (TLVector<TLAbsMessageEntity>)ObjectUtils.DeserializeVector<TLAbsMessageEntity>(br);
            else
                Entities = null;

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
            bw.Write(FromId);
            bw.Write(ChatId);
            StringUtil.Serialize(Message, bw);
            bw.Write(Pts);
            bw.Write(PtsCount);
            bw.Write(Date);
            if ((Flags & 4) != 0)
                ObjectUtils.SerializeObject(FwdFrom, bw);
            if ((Flags & 2048) != 0)
                bw.Write(ViaBotId.Value);
            if ((Flags & 8) != 0)
                ObjectUtils.SerializeObject(ReplyTo, bw);
            if ((Flags & 128) != 0)
                ObjectUtils.SerializeObject(Entities, bw);
            if ((Flags & 33554432) != 0)
                bw.Write(TtlPeriod.Value);

        }
    }
}
