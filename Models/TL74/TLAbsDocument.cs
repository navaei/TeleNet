namespace TeleNet.Models.TL
{
    public abstract class TLAbsDocument : TLObject
    {
        public long Id { get; set; }
        public long AccessHash { get; set; }
        public int Date { get; set; }
        public string MimeType { get; set; }
        public int Size { get; set; }
        public TLAbsPhotoSize Thumb { get; set; }
        public int DcId { get; set; }
        public byte[] FileReference { get; set; }
        public TLVector<TLAbsDocumentAttribute> Attributes { get; set; }
    }
}
