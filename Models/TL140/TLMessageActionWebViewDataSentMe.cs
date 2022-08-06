using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL140
{
	[TLObject(1205698681)]
    public class TLMessageActionWebViewDataSentMe : TLAbsMessageAction
    {
        public override int Constructor
        {
            get
            {
                return 1205698681;
            }
        }

             public string Text {get;set;}
     public string Data {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Text = StringUtil.Deserialize(br);
Data = StringUtil.Deserialize(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            StringUtil.Serialize(Text,bw);
StringUtil.Serialize(Data,bw);

        }
    }
}
