namespace TeleNet.Models.TL.Auth
{
    public abstract class TLAbsExportedAuthorization : TLObject
    {
        public long Id { get; set; }
        public byte[] Bytes { get; set; }
    }
}