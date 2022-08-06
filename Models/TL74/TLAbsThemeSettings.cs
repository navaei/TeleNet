
using TeleNet.Models.TL111;


namespace TeleNet.Models.TL
{
   
    public abstract class TLAbsThemeSettings : TLObject
    {
        public int Flags { get; set; }
        public bool MessageColorsAnimated { get; set; }
        public TLAbsBaseTheme BaseTheme { get; set; }
        public int AccentColor { get; set; }
        public int? OutboxAccentColor { get; set; }
        public TLVector<int> MessageColors { get; set; }
        public TLAbsWallPaper Wallpaper { get; set; }
    }
}
