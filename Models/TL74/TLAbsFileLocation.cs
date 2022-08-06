namespace TeleNet.Models.TL
{
    public abstract class TLAbsFileLocation : TLObject
    {
        public int DcId { get; set; }
        public long VolumeId { get; set; }
        public int LocalId { get; set; }
        public long Secret { get; set; }
        public byte[] FileReference { get; set; }

    }
}
