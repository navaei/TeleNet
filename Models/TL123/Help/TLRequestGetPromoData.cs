using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL123.Help
{
	[TLObject(-1063816159)]
    public class TLRequestGetPromoData : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return -1063816159;
            }
        }

        public Help.TLAbsPromoData Response { get; set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            
        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            
        }

		public override void DeserializeResponse(BinaryReader br)
		{
			Response = (Help.TLAbsPromoData)ObjectUtils.DeserializeObject(br);

		}
    }
}
