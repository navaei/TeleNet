using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL140.Messages
{
	[TLObject(451818415)]
    public class TLRequestToggleBotInAttachMenu : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return 451818415;
            }
        }

                public TLAbsInputUser Bot {get;set;}
        public bool Enabled {get;set;}
public bool Response { get; set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Bot = (TLAbsInputUser)ObjectUtils.DeserializeObject(br);
Enabled = BoolUtil.Deserialize(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            ObjectUtils.SerializeObject(Bot,bw);
BoolUtil.Serialize(Enabled,bw);

        }

		public override void DeserializeResponse(BinaryReader br)
		{
			Response = BoolUtil.Deserialize(br);

		}
    }
}
