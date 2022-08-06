using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace  TeleNet.Models.TL111
{
	[TLObject(-1237848657)]
    public class TLStatsDateRangeDays : TLObject
    {
        public override int Constructor
        {
            get
            {
                return -1237848657;
            }
        }

             public int MinDate {get;set;}
     public int MaxDate {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            MinDate = br.ReadInt32();
MaxDate = br.ReadInt32();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            bw.Write(MinDate);
bw.Write(MaxDate);

        }
    }
}
