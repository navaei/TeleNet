using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace  TeleNet.Models.TL96
{
	[TLObject(-1590738760)]
    public class TLWallPaperSettings : TLObject
    {
        public override int Constructor
        {
            get
            {
                return -1590738760;
            }
        }

             public int Flags {get;set;}
     public bool Blur {get;set;}
     public bool Motion {get;set;}
     public int? BackgroundColor {get;set;}
     public int? Intensity {get;set;}


		public void ComputeFlags()
		{
			Flags = 0;
Flags = Blur ? (Flags | 2) : (Flags & ~2);
Flags = Motion ? (Flags | 4) : (Flags & ~4);
Flags = BackgroundColor != null ? (Flags | 1) : (Flags & ~1);
Flags = Intensity != null ? (Flags | 8) : (Flags & ~8);

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

if ((Flags & 8) != 0)
Intensity = br.ReadInt32();
else
Intensity = null;


        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            ComputeFlags();
bw.Write(Flags);


if ((Flags & 1) != 0)
bw.Write(BackgroundColor.Value);
if ((Flags & 8) != 0)
bw.Write(Intensity.Value);

        }
    }
}
