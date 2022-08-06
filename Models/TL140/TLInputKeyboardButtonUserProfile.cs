using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL140
{
	[TLObject(-376962181)]
    public class TLInputKeyboardButtonUserProfile : TLAbsKeyboardButton
    {
        public override int Constructor
        {
            get
            {
                return -376962181;
            }
        }

             public string Text {get;set;}
     public TLAbsInputUser UserId {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Text = StringUtil.Deserialize(br);
UserId = (TLAbsInputUser)ObjectUtils.DeserializeObject(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            StringUtil.Serialize(Text,bw);
ObjectUtils.SerializeObject(UserId,bw);

        }
    }
}
