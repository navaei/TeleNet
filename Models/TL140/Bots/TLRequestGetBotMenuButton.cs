using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL140.Bots
{
	[TLObject(-1671369944)]
    public class TLRequestGetBotMenuButton : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return -1671369944;
            }
        }

                public TLAbsInputUser UserId {get;set;}
public TLAbsBotMenuButton Response { get; set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            UserId = (TLAbsInputUser)ObjectUtils.DeserializeObject(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            ObjectUtils.SerializeObject(UserId,bw);

        }

		public override void DeserializeResponse(BinaryReader br)
		{
			Response = (TLAbsBotMenuButton)ObjectUtils.DeserializeObject(br);

		}
    }
}
