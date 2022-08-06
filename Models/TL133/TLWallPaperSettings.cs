using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL133
{
    [TLObject(499236004)]
    public class TLWallPaperSettings : TLAbsWallPaperSettings
    {
        public override int Constructor
        {
            get
            {
                return 499236004;
            }
        }

        public int Flags { get; set; }
        public bool Blur { get; set; }
        public bool Motion { get; set; }
        public int? BackgroundColor { get; set; }
        public int? SecondBackgroundColor { get; set; }
        public int? ThirdBackgroundColor { get; set; }
        public int? FourthBackgroundColor { get; set; }
        public int? Intensity { get; set; }
        public int? Rotation { get; set; }


        public void ComputeFlags()
        {
            Flags = 0;
            Flags = Blur ? (Flags | 2) : (Flags & ~2);
            Flags = Motion ? (Flags | 4) : (Flags & ~4);
            Flags = BackgroundColor != null ? (Flags | 1) : (Flags & ~1);
            Flags = SecondBackgroundColor != null ? (Flags | 16) : (Flags & ~16);
            Flags = ThirdBackgroundColor != null ? (Flags | 32) : (Flags & ~32);
            Flags = FourthBackgroundColor != null ? (Flags | 64) : (Flags & ~64);
            Flags = Intensity != null ? (Flags | 8) : (Flags & ~8);
            Flags = Rotation != null ? (Flags | 16) : (Flags & ~16);

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
            Blur = (Flags & 2) != 0;
            Motion = (Flags & 4) != 0;
            if ((Flags & 1) != 0)
                BackgroundColor = br.ReadInt32();
            else
                BackgroundColor = null;

            if ((Flags & 16) != 0)
                SecondBackgroundColor = br.ReadInt32();
            else
                SecondBackgroundColor = null;

            if ((Flags & 32) != 0)
                ThirdBackgroundColor = br.ReadInt32();
            else
                ThirdBackgroundColor = null;

            if ((Flags & 64) != 0)
                FourthBackgroundColor = br.ReadInt32();
            else
                FourthBackgroundColor = null;

            if ((Flags & 8) != 0)
                Intensity = br.ReadInt32();
            else
                Intensity = null;

            if ((Flags & 16) != 0)
                Rotation = br.ReadInt32();
            else
                Rotation = null;


        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ComputeFlags();
            bw.Write(Flags);


            if ((Flags & 1) != 0)
                bw.Write(BackgroundColor.Value);
            if ((Flags & 16) != 0)
                bw.Write(SecondBackgroundColor.Value);
            if ((Flags & 32) != 0)
                bw.Write(ThirdBackgroundColor.Value);
            if ((Flags & 64) != 0)
                bw.Write(FourthBackgroundColor.Value);
            if ((Flags & 8) != 0)
                bw.Write(Intensity.Value);
            if ((Flags & 16) != 0)
                bw.Write(Rotation.Value);

        }
    }
}
