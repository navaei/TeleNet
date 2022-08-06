namespace TeleNet.Models.TL.Messages
{
    public abstract class TLAbsSavedGifs : TLObject
    {
        public TLVector<TLAbsDocument> Gifs { get; set; }
    }
}
