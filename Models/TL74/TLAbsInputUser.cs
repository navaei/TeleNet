namespace TeleNet.Models.TL
{
    public abstract class TLAbsInputUser : TLObject
    {
        public long UserId { get; set; }
        public long AccessHash { get; set; }
    }
}
