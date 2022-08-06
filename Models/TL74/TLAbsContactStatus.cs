namespace TeleNet.Models.TL
{
    public abstract class TLAbsContactStatus : TLObject
    {
        public long UserId { get; set; }
        public TLAbsUserStatus Status { get; set; }
    }
}