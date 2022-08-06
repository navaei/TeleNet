using System;
using System.Collections.Generic;
using System.Text;

namespace TeleNet.Models.TL
{
    public abstract class TLAbsInputThemeSettings : TLObject
    {
        public TeleNet.Models.TL.TLAbsBaseTheme BaseTheme { get; set; }
        public int AccentColor { get; set; }
        public int? OutboxAccentColor { get; set; }
        public TLVector<int> MessageColors { get; set; }
        public TL96.TLAbsInputWallPaper Wallpaper { get; set; }
        public TLAbsWallPaperSettings WallpaperSettings { get; set; }
    }
}
