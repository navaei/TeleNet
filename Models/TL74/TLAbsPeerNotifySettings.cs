namespace TeleNet.Models.TL
{
    public abstract class TLAbsPeerNotifySettings : TLObject
    {
        public int Flags { get; set; }
        public bool? ShowPreviews { get; set; }
        public bool? Silent { get; set; }
        public int? MuteUntil { get; set; }
        public string Sound { get; set; }
    }
}
