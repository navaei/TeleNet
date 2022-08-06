using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL133.Account
{
	[TLObject(-478701471)]
    public class TLResetPasswordFailedWait : TLAbsResetPasswordResult
    {
        public override int Constructor
        {
            get
            {
                return -478701471;
            }
        }

             public int RetryDate {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            RetryDate = br.ReadInt32();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            bw.Write(RetryDate);

        }
    }
}
