using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;
using TeleNet.Models.TL.Messages;

namespace  TeleNet.Models.TL100.Channels
{
	[TLObject(445117188)]
    public class TLRequestGetBroadcastsForDiscussion : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return 445117188;
            }
        }

        public TLAbsChats Response { get; set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            
        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            
        }

		public override void DeserializeResponse(BinaryReader br)
		{
			Response = (TLAbsChats)ObjectUtils.DeserializeObject(br);

		}
    }
}
