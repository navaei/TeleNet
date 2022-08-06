namespace TeleNet.Models.TL
{
    public abstract class TLAbsMessageService : TLAbsMessage
    {
        public bool Legacy { get; set; }
        public TLAbsPeer PeerId { get; set; }
        public TLAbsMessageAction Action { get; set; }

    }

}
