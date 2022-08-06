namespace TeleNet.Models.TL.Messages
{
    public abstract class TLAbsAllStickers : TLObject
    {
        public TLVector<TLAbsStickerSet> Sets { get; set; }
        public long Hash { get; set; }
    }
}
