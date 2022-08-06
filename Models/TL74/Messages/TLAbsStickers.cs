namespace TeleNet.Models.TL.Messages
{
    public abstract class TLAbsStickers : TLObject
    {
        public TLVector<TLAbsDocument> Stickers { get; set; }

    }
}
