namespace TeleNet.Models.TL
{
    public abstract class TLAbsChat : TLObject
    {
        public int Flags { get; set; }
        public long Id { get; set; }
        public int Date { get; set; }
        public string Title { get; set; }
        public bool Editor { get; set; }
        public bool Creator { get; set; }
        public bool Left { get; set; }
        public int Version { get; set; }

        public bool Broadcast { get; set; }
        public bool Verified { get; set; }
        public bool Megagroup { get; set; }
        public bool Democracy { get; set; }

        public TLAbsChatAdminRights AdminRights { get; set; }
        public TLAbsChatBannedRights BannedRights { get; set; }
        public TLAbsChatBannedRights DefaultBannedRights { get; set; }
        public int? ParticipantsCount { get; set; }
        public string Username { get; set; }
        public TLAbsChatPhoto Photo { get; set; }
        public bool Restricted { get; set; }


    }
}
