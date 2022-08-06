using System.IO;
using TeleNet.Models.TL;
using TeleNet.Models.TL111;

namespace TeleNet.Models.TL123
{
    [TLObject(1487813065)]
    public class TLMessage : TLAbsMessage
    {
        public override int Constructor
        {
            get
            {
                return 1487813065;
            }
        }

        public TLAbsPeer PeerId { get; set; }

        public bool FromScheduled { get; set; }
        public bool Legacy { get; set; }
        public bool EditHide { get; set; }
        public bool Pinned { get; set; }

        public string PostAuthor { get; set; }
        public long? GroupedId { get; set; }
        public TLVector<TLRestrictionReason> RestrictionReason { get; set; }


        public void ComputeFlags()
        {
            Flags = 0;
            Flags = Out ? (Flags | 2) : (Flags & ~2);
            Flags = Mentioned ? (Flags | 16) : (Flags & ~16);
            Flags = MediaUnread ? (Flags | 32) : (Flags & ~32);
            Flags = Silent ? (Flags | 8192) : (Flags & ~8192);
            Flags = Post ? (Flags | 16384) : (Flags & ~16384);
            Flags = FromScheduled ? (Flags | 262144) : (Flags & ~262144);
            Flags = Legacy ? (Flags | 524288) : (Flags & ~524288);
            Flags = EditHide ? (Flags | 2097152) : (Flags & ~2097152);
            Flags = Pinned ? (Flags | 16777216) : (Flags & ~16777216);
            Flags = FromId != null ? (Flags | 256) : (Flags & ~256);
            Flags = FwdFrom != null ? (Flags | 4) : (Flags & ~4);
            Flags = ViaBotId != null ? (Flags | 2048) : (Flags & ~2048);
            Flags = ReplyTo != null ? (Flags | 8) : (Flags & ~8);
            Flags = Media != null ? (Flags | 512) : (Flags & ~512);
            Flags = ReplyMarkup != null ? (Flags | 64) : (Flags & ~64);
            Flags = Entities != null ? (Flags | 128) : (Flags & ~128);
            Flags = Views != null ? (Flags | 1024) : (Flags & ~1024);
            Flags = Forwards != null ? (Flags | 1024) : (Flags & ~1024);
            Flags = Replies != null ? (Flags | 8388608) : (Flags & ~8388608);
            Flags = EditDate != null ? (Flags | 32768) : (Flags & ~32768);
            Flags = PostAuthor != null ? (Flags | 65536) : (Flags & ~65536);
            Flags = GroupedId != null ? (Flags | 131072) : (Flags & ~131072);
            Flags = RestrictionReason != null ? (Flags | 4194304) : (Flags & ~4194304);

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
            Out = (Flags & 2) != 0;
            Mentioned = (Flags & 16) != 0;
            MediaUnread = (Flags & 32) != 0;
            Silent = (Flags & 8192) != 0;
            Post = (Flags & 16384) != 0;
            FromScheduled = (Flags & 262144) != 0;
            Legacy = (Flags & 524288) != 0;
            EditHide = (Flags & 2097152) != 0;
            Pinned = (Flags & 16777216) != 0;
            Id = br.ReadInt32();
            if ((Flags & 256) != 0)
                FromId = (TLAbsPeer)ObjectUtils.DeserializeObject(br);
            else
                FromId = null;

            PeerId = (TLAbsPeer)ObjectUtils.DeserializeObject(br);
            if ((Flags & 4) != 0)
                FwdFrom = (TLMessageFwdHeader)ObjectUtils.DeserializeObject(br);
            else
                FwdFrom = null;

            if ((Flags & 2048) != 0)
                ViaBotId = br.ReadInt32();
            else
                ViaBotId = null;

            if ((Flags & 8) != 0)
                ReplyTo = (TLMessageReplyHeader)ObjectUtils.DeserializeObject(br);
            else
                ReplyTo = null;

            Date = br.ReadInt32();
            Message = StringUtil.Deserialize(br);
            if ((Flags & 512) != 0)
                Media = (TLAbsMessageMedia)ObjectUtils.DeserializeObject(br);
            else
                Media = null;

            if ((Flags & 64) != 0)
                ReplyMarkup = (TLAbsReplyMarkup)ObjectUtils.DeserializeObject(br);
            else
                ReplyMarkup = null;

            if ((Flags & 128) != 0)
                Entities = ObjectUtils.DeserializeVector<TLAbsMessageEntity>(br);
            else
                Entities = null;

            if ((Flags & 1024) != 0)
                Views = br.ReadInt32();
            else
                Views = null;

            if ((Flags & 1024) != 0)
                Forwards = br.ReadInt32();
            else
                Forwards = null;

            if ((Flags & 8388608) != 0)
                Replies = (TLAbsMessageReplies)ObjectUtils.DeserializeObject(br);
            else
                Replies = null;

            if ((Flags & 32768) != 0)
                EditDate = br.ReadInt32();
            else
                EditDate = null;

            if ((Flags & 65536) != 0)
                PostAuthor = StringUtil.Deserialize(br);
            else
                PostAuthor = null;

            if ((Flags & 131072) != 0)
                GroupedId = br.ReadInt64();
            else
                GroupedId = null;

            if ((Flags & 4194304) != 0)
                RestrictionReason = (TLVector<TLRestrictionReason>)ObjectUtils.DeserializeVector<TLRestrictionReason>(br);
            else
                RestrictionReason = null;


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
            if ((Flags & 4) != 0)
                ObjectUtils.SerializeObject(FwdFrom, bw);
            if ((Flags & 2048) != 0)
                bw.Write(ViaBotId.Value);
            if ((Flags & 8) != 0)
                ObjectUtils.SerializeObject(ReplyTo, bw);
            bw.Write(Date);
            StringUtil.Serialize(Message, bw);
            if ((Flags & 512) != 0)
                ObjectUtils.SerializeObject(Media, bw);
            if ((Flags & 64) != 0)
                ObjectUtils.SerializeObject(ReplyMarkup, bw);
            if ((Flags & 128) != 0)
                ObjectUtils.SerializeObject(Entities, bw);
            if ((Flags & 1024) != 0)
                bw.Write(Views.Value);
            if ((Flags & 1024) != 0)
                bw.Write(Forwards.Value);
            if ((Flags & 8388608) != 0)
                ObjectUtils.SerializeObject(Replies, bw);
            if ((Flags & 32768) != 0)
                bw.Write(EditDate.Value);
            if ((Flags & 65536) != 0)
                StringUtil.Serialize(PostAuthor, bw);
            if ((Flags & 131072) != 0)
                bw.Write(GroupedId.Value);
            if ((Flags & 4194304) != 0)
                ObjectUtils.SerializeObject(RestrictionReason, bw);

        }
    }
}
