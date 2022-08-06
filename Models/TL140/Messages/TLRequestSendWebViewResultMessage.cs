using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL140.Messages
{
	[TLObject(172168437)]
    public class TLRequestSendWebViewResultMessage : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return 172168437;
            }
        }

                public string BotQueryId {get;set;}
        public TLAbsInputBotInlineResult Result {get;set;}
public TLWebViewMessageSent Response { get; set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            BotQueryId = StringUtil.Deserialize(br);
Result = (TLAbsInputBotInlineResult)ObjectUtils.DeserializeObject(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            StringUtil.Serialize(BotQueryId,bw);
ObjectUtils.SerializeObject(Result,bw);

        }

		public override void DeserializeResponse(BinaryReader br)
		{
			Response = (TLWebViewMessageSent)ObjectUtils.DeserializeObject(br);

		}
    }
}
