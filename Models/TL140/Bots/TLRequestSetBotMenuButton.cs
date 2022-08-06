using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL140.Bots
{
	[TLObject(1157944655)]
    public class TLRequestSetBotMenuButton : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return 1157944655;
            }
        }

                public TLAbsInputUser UserId {get;set;}
        public TLAbsBotMenuButton Button {get;set;}
public bool Response { get; set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            UserId = (TLAbsInputUser)ObjectUtils.DeserializeObject(br);
Button = (TLAbsBotMenuButton)ObjectUtils.DeserializeObject(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            ObjectUtils.SerializeObject(UserId,bw);
ObjectUtils.SerializeObject(Button,bw);

        }

		public override void DeserializeResponse(BinaryReader br)
		{
			Response = BoolUtil.Deserialize(br);

		}
    }
}
