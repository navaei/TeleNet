using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL133
{
	[TLObject(-1660637285)]
    public class TLStatsGroupTopPoster : TLObject
    {
        public override int Constructor
        {
            get
            {
                return -1660637285;
            }
        }

             public long UserId {get;set;}
     public int Messages {get;set;}
     public int AvgChars {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            UserId = br.ReadInt64();
Messages = br.ReadInt32();
AvgChars = br.ReadInt32();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            bw.Write(UserId);
bw.Write(Messages);
bw.Write(AvgChars);

        }
    }
}
