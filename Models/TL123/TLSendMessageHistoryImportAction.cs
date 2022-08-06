using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL123
{
	[TLObject(-606432698)]
    public class TLSendMessageHistoryImportAction : TLAbsSendMessageAction
    {
        public override int Constructor
        {
            get
            {
                return -606432698;
            }
        }

             public int Progress {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Progress = br.ReadInt32();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            bw.Write(Progress);

        }
    }
}
