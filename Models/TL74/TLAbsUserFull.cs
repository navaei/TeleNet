namespace TeleNet.Models.TL
{
    public abstract class TLAbsUserFull : TLObject
    {
        public int Flags { get; set; }
        public bool Blocked { get; set; }
        public bool PhoneCallsAvailable { get; set; }
        public bool PhoneCallsPrivate { get; set; }
        public bool CanPinMessage { get; set; }
        public TLAbsUser User { get; set; }
        public string About { get; set; }
        public TL.Contacts.TLLink Link { get; set; }
        public virtual TLAbsPhoto ProfilePhoto { get; set; }
        public TLAbsPeerNotifySettings NotifySettings { get; set; }
        public TLAbsPeerSettings Settings { get; set; }
        public TLAbsBotInfo BotInfo { get; set; }
        public int? PinnedMsgId { get; set; }
        public int CommonChatsCount { get; set; }

        public int? FolderId { get; set; }

        public bool HasScheduled { get; set; }
        public bool VideoCallsAvailable { get; set; }
    }
}