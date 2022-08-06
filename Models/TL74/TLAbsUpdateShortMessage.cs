namespace TeleNet.Models.TL
{
    public abstract class TLAbsUpdateShortMessage : TLAbsUpdates
    {
        public int Flags { get; set; }
        public bool Out { get; set; }
        public bool Mentioned { get; set; }
        public bool MediaUnread { get; set; }
        public bool Silent { get; set; }
        public int Id { get; set; }
        public long UserId { get; set; }
        public string Message { get; set; }
        public int Pts { get; set; }
        public int PtsCount { get; set; }
        public int Date { get; set; }
        public TLAbsMessageFwdHeader FwdFrom { get; set; }
        public long? ViaBotId { get; set; }
        public TL123.TLMessageReplyHeader ReplyTo { get; set; }
        public TLVector<TLAbsMessageEntity> Entities { get; set; }
    }
}