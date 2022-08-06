namespace TeleNet.Models.TL
{
    public abstract class TLAbsInputChannel : TLObject
    {
        public long ChannelId { get; set; }
        public long AccessHash { get; set; }
    }
}
