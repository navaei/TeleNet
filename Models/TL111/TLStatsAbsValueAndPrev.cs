using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace  TeleNet.Models.TL111
{
	[TLObject(-884757282)]
    public class TLStatsAbsValueAndPrev : TLObject
    {
        public override int Constructor
        {
            get
            {
                return -884757282;
            }
        }

             public double Current {get;set;}
     public double Previous {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Current = br.ReadDouble();
Previous = br.ReadDouble();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            bw.Write(Current);
bw.Write(Previous);

        }
    }
}
