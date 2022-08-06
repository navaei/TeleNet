namespace TeleNet.Models.TL.Auth
{
    public abstract class TLAbsAuthorization : TLObject
    {
        public int Flags { get; set; }
        public int? TmpSessions { get; set; }
        public TLAbsUser User { get; set; }
    }
}
