using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL133
{
    [TLObject(-94849324)]
    public class TLThemeSettings : TL.TLAbsThemeSettings
    {
        public override int Constructor
        {
            get
            {
                return -94849324;
            }
        }


        public void ComputeFlags()
        {
            Flags = 0;
            Flags = MessageColorsAnimated ? (Flags | 4) : (Flags & ~4);
            Flags = OutboxAccentColor != null ? (Flags | 8) : (Flags & ~8);
            Flags = MessageColors != null ? (Flags | 1) : (Flags & ~1);
            Flags = Wallpaper != null ? (Flags | 2) : (Flags & ~2);

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
            MessageColorsAnimated = (Flags & 4) != 0;
            BaseTheme = (TLAbsBaseTheme)ObjectUtils.DeserializeObject(br);
            AccentColor = br.ReadInt32();
            if ((Flags & 8) != 0)
                OutboxAccentColor = br.ReadInt32();
            else
                OutboxAccentColor = null;

            if ((Flags & 1) != 0)
                MessageColors = (TLVector<int>)ObjectUtils.DeserializeVector<int>(br);
            else
                MessageColors = null;

            if ((Flags & 2) != 0)
                Wallpaper = (TLWallPaper)ObjectUtils.DeserializeObject(br);
            else
                Wallpaper = null;


        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ComputeFlags();
            bw.Write(Flags);

            ObjectUtils.SerializeObject(BaseTheme, bw);
            bw.Write(AccentColor);
            if ((Flags & 8) != 0)
                bw.Write(OutboxAccentColor.Value);
            if ((Flags & 1) != 0)
                ObjectUtils.SerializeObject(MessageColors, bw);
            if ((Flags & 2) != 0)
                ObjectUtils.SerializeObject(Wallpaper, bw);

        }
    }
}
