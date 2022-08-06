using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL133.Messages
{
	[TLObject(-1571952873)]
    public class TLCheckedHistoryImportPeer : TLObject
    {
        public override int Constructor
        {
            get
            {
                return -1571952873;
            }
        }

             public string ConfirmText {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            ConfirmText = StringUtil.Deserialize(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            StringUtil.Serialize(ConfirmText,bw);

        }
    }
}
