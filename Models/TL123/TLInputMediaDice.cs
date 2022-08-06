using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL123
{
	[TLObject(-428884101)]
    public class TLInputMediaDice : TLAbsInputMedia
    {
        public override int Constructor
        {
            get
            {
                return -428884101;
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
