using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace  TeleNet.Models.TL100
{
	[TLObject(-1886646706)]
    public class TLUrlAuthResultAccepted : TLAbsUrlAuthResult
    {
        public override int Constructor
        {
            get
            {
                return -1886646706;
            }
        }

             public string Url {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Url = StringUtil.Deserialize(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            StringUtil.Serialize(Url,bw);

        }
    }
}
