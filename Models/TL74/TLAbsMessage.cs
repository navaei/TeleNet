namespace TeleNet.Models.TL
{
    public abstract class TLAbsMessage : TLObject
    {
        public int Id { get; set; }
        public TLAbsPeer FromId { get; set; }

        public int Flags { get; set; }
        public bool Out { get; set; }
        public bool Mentioned { get; set; }
        public bool MediaUnread { get; set; }
        public bool Silent { get; set; }
        public bool Post { get; set; }
        public int? Views { get; set; }

        public int Date { get; set; }
        public string Message { get; set; }
        public long? ViaBotId { get; set; }

        public TLAbsMessageFwdHeader FwdFrom { get; set; }
        public TLVector<TLAbsMessageEntity> Entities { get; set; }
        public TLAbsMessageMedia Media { get; set; }
        public TLAbsReplyMarkup ReplyMarkup { get; set; }

        //only for layer 123 133
        public TL123.TLMessageReplyHeader ReplyTo { get; set; }
        public TLAbsMessageReplies Replies { get; set; }

        public int? Forwards { get; set; }
        public bool IsMessageService { get; set; }
        public int? EditDate { get; set; }
    }
}
