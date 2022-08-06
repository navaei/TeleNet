using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL140.Auth
{
	[TLObject(1047706137)]
    public class TLRequestLogOut : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return 1047706137;
            }
        }

        public Auth.TLLoggedOut Response { get; set;}


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
			Response = (Auth.TLLoggedOut)ObjectUtils.DeserializeObject(br);

		}
    }
}
