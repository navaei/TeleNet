using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL133
{
	[TLObject(-1234857938)]
    public class TLSendMessageEmojiInteractionSeen : TLAbsSendMessageAction
    {
        public override int Constructor
        {
            get
            {
                return -1234857938;
            }
        }

             public string Emoticon {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Emoticon = StringUtil.Deserialize(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            StringUtil.Serialize(Emoticon,bw);

        }
    }
}
