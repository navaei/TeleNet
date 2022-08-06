using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL133.Account
{
	[TLObject(-370148227)]
    public class TLResetPasswordRequestedWait : TLAbsResetPasswordResult
    {
        public override int Constructor
        {
            get
            {
                return -370148227;
            }
        }

             public int UntilDate {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            UntilDate = br.ReadInt32();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            bw.Write(UntilDate);

        }
    }
}
