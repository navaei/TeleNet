using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace  TeleNet.Models.TL96
{
	[TLObject(-767099577)]
    public class TLAutoDownloadSettings : TLObject
    {
        public override int Constructor
        {
            get
            {
                return -767099577;
            }
        }

             public int Flags {get;set;}
     public bool Disabled {get;set;}
     public bool VideoPreloadLarge {get;set;}
     public bool AudioPreloadNext {get;set;}
     public bool PhonecallsLessData {get;set;}
     public int PhotoSizeMax {get;set;}
     public int VideoSizeMax {get;set;}
     public int FileSizeMax {get;set;}


		public void ComputeFlags()
		{
			Flags = 0;
Flags = Disabled ? (Flags | 1) : (Flags & ~1);
Flags = VideoPreloadLarge ? (Flags | 2) : (Flags & ~2);
Flags = AudioPreloadNext ? (Flags | 4) : (Flags & ~4);
Flags = PhonecallsLessData ? (Flags | 8) : (Flags & ~8);

		}

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
Disabled = (Flags & 1) != 0;
VideoPreloadLarge = (Flags & 2) != 0;
AudioPreloadNext = (Flags & 4) != 0;
PhonecallsLessData = (Flags & 8) != 0;
PhotoSizeMax = br.ReadInt32();
VideoSizeMax = br.ReadInt32();
FileSizeMax = br.ReadInt32();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            ComputeFlags();
bw.Write(Flags);




bw.Write(PhotoSizeMax);
bw.Write(VideoSizeMax);
bw.Write(FileSizeMax);

        }
    }
}
