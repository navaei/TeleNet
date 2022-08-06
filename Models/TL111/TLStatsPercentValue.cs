using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace  TeleNet.Models.TL111
{
	[TLObject(-875679776)]
    public class TLStatsPercentValue : TLObject
    {
        public override int Constructor
        {
            get
            {
                return -875679776;
            }
        }

             public double Part {get;set;}
     public double Total {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Part = br.ReadDouble();
Total = br.ReadDouble();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            bw.Write(Part);
bw.Write(Total);

        }
    }
}
