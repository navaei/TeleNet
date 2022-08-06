using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;
using TeleNet.Models.TL.Account;

namespace  TeleNet.Models.TL111.Account
{
	[TLObject(-199313886)]
    public class TLThemesNotModified : TLAbsThemes
    {
        public override int Constructor
        {
            get
            {
                return -199313886;
            }
        }

        

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
    }
}
