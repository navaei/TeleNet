using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL140
{
	[TLObject(814112961)]
    public class TLKeyboardButtonUserProfile : TLAbsKeyboardButton
    {
        public override int Constructor
        {
            get
            {
                return 814112961;
            }
        }

             public string Text {get;set;}
     public long UserId {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Text = StringUtil.Deserialize(br);
UserId = br.ReadInt64();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            StringUtil.Serialize(Text,bw);
bw.Write(UserId);

        }
    }
}
