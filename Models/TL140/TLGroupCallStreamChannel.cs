using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL140
{
	[TLObject(-2132064081)]
    public class TLGroupCallStreamChannel : TLObject
    {
        public override int Constructor
        {
            get
            {
                return -2132064081;
            }
        }

             public int Channel {get;set;}
     public int Scale {get;set;}
     public long LastTimestampMs {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Channel = br.ReadInt32();
Scale = br.ReadInt32();
LastTimestampMs = br.ReadInt64();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            bw.Write(Channel);
bw.Write(Scale);
bw.Write(LastTimestampMs);

        }
    }
}
