using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL123.Help
{
	[TLObject(1935116200)]
    public class TLRequestGetCountriesList : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return 1935116200;
            }
        }

                public string LangCode {get;set;}
        public int Hash {get;set;}
public Help.TLAbsCountriesList Response { get; set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            LangCode = StringUtil.Deserialize(br);
Hash = br.ReadInt32();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            StringUtil.Serialize(LangCode,bw);
bw.Write(Hash);

        }

		public override void DeserializeResponse(BinaryReader br)
		{
			Response = (Help.TLAbsCountriesList)ObjectUtils.DeserializeObject(br);

		}
    }
}
