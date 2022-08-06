namespace TeleNet.Models.TL
{
    public abstract class TLAbsPhoto : TLObject
    {
        public int Flags { get; set; }
        public long Id { get; set; }
        public long AccessHash { get; set; }
        public bool HasStickers { get; set; }
        public int Date { get; set; }
        public TLVector<TLAbsPhotoSize> Sizes { get; set; }

        public byte[] FileReference { get; set; }
        public int DcId { get; set; }
        public TLVector<TLAbsVideoSize> VideoSizes { get; set; }

    }
}
