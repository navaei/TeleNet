namespace TeleNet.Models.TL
{
    public abstract class TLAbsPeerSettings : TLObject
    {
        public int Flags { get; set; }
        public bool ReportSpam { get; set; }

        public bool AddContact { get; set; }
        public bool BlockContact { get; set; }
        public bool ShareContact { get; set; }
        public bool NeedContactsException { get; set; }
        public bool ReportGeo { get; set; }
        public bool Autoarchived { get; set; }
        public bool InviteMembers { get; set; }
        public int? GeoDistance { get; set; }

    }
}