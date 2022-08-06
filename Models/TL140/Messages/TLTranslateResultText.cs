using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL140.Messages
{
	[TLObject(-1575684144)]
    public class TLTranslateResultText : TLAbsTranslatedText
    {
        public override int Constructor
        {
            get
            {
                return -1575684144;
            }
        }

             public string Text {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Text = StringUtil.Deserialize(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            StringUtil.Serialize(Text,bw);

        }
    }
}
