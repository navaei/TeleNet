namespace TeleNet.Models.TL
{
    public abstract class TLAbsExportedChatInvite : TLObject
    {
        public int Flags { get; set; }
        public bool Revoked { get; set; }
        public bool Permanent { get; set; }
        public string Link { get; set; }
        public long AdminId { get; set; }
        public int Date { get; set; }
        public int? StartDate { get; set; }
        public int? ExpireDate { get; set; }
        public int? UsageLimit { get; set; }
        public int? Usage { get; set; }
    }
}
