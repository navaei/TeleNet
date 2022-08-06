namespace TeleNet.Models.TL
{
    public abstract class TLAbsImportedContact : TLObject
    {
        public long ClientId { get; set; }
        public long UserId { get; set; }

    }
}