using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL123.Help
{
	[TLObject(-2016381538)]
    public class TLCountriesList : TLAbsCountriesList
    {
        public override int Constructor
        {
            get
            {
                return -2016381538;
            }
        }

             public TLVector<Help.TLCountry> Countries {get;set;}
     public int Hash {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Countries = (TLVector<Help.TLCountry>)ObjectUtils.DeserializeVector<Help.TLCountry>(br);
Hash = br.ReadInt32();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            ObjectUtils.SerializeObject(Countries,bw);
bw.Write(Hash);

        }
    }
}
