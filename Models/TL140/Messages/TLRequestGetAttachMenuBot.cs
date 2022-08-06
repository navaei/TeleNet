using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL140.Messages
{
	[TLObject(1998676370)]
    public class TLRequestGetAttachMenuBot : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return 1998676370;
            }
        }

                public TLAbsInputUser Bot {get;set;}
public TLAttachMenuBotsBot Response { get; set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Bot = (TLAbsInputUser)ObjectUtils.DeserializeObject(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            ObjectUtils.SerializeObject(Bot,bw);

        }

		public override void DeserializeResponse(BinaryReader br)
		{
			Response = (TLAttachMenuBotsBot)ObjectUtils.DeserializeObject(br);

		}
    }
}
