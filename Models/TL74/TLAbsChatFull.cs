namespace TeleNet.Models.TL
{
    public abstract class TLAbsChatFull : TLObject
    {
        public long Id { get; set; }
        public int Flags { get; set; }
    }
}
