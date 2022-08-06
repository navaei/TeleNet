using System.IO;
using TeleNet.Models.TL;

namespace  TeleNet.Models.TL85.Help
{
	[TLObject(-1600596305)]
    public class TLPassportConfig : TLAbsPassportConfig
    {
        public override int Constructor
        {
            get
            {
                return -1600596305;
            }
        }

             public int Hash {get;set;}
     public TLDataJSON CountriesLangs {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Hash = br.ReadInt32();
CountriesLangs = (TLDataJSON)ObjectUtils.DeserializeObject(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            bw.Write(Hash);
ObjectUtils.SerializeObject(CountriesLangs,bw);

        }
    }
}
