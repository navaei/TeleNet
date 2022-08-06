namespace TeleNet.Models.TL
{
    public abstract class TLAbsPhotoSize : TLObject
    {
        public TLAbsFileLocation Location { get; set; }
        public string Type { get; set; }
        public int W { get; set; }
        public int H { get; set; }
        public byte[] Bytes { get; set; }
    }
}
