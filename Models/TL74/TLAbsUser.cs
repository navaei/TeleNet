namespace TeleNet.Models.TL
{
    public abstract class TLAbsUser : TLObject
    {
        public long Id { get; set; }

        public int Flags { get; set; }
        public bool Self { get; set; }
        public bool Contact { get; set; }
        public bool MutualContact { get; set; }
        public bool Deleted { get; set; }
        public bool Bot { get; set; }
        public bool BotChatHistory { get; set; }
        public bool BotNochats { get; set; }
        public bool Verified { get; set; }
        public bool Restricted { get; set; }
        public bool Min { get; set; }
        public bool BotInlineGeo { get; set; }
        public bool Support { get; set; }
        public long? AccessHash { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Phone { get; set; }
        public TLAbsUserProfilePhoto Photo { get; set; }
        public TLAbsUserStatus Status { get; set; }
        public int? BotInfoVersion { get; set; }
        public string BotInlinePlaceholder { get; set; }
        public string LangCode { get; set; }
    }
}
