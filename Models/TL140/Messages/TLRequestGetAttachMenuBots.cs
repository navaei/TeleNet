using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL140.Messages
{
	[TLObject(385663691)]
    public class TLRequestGetAttachMenuBots : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return 385663691;
            }
        }

                public long Hash {get;set;}
public TLAbsAttachMenuBots Response { get; set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Hash = br.ReadInt64();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            bw.Write(Hash);

        }

		public override void DeserializeResponse(BinaryReader br)
		{
			Response = (TLAbsAttachMenuBots)ObjectUtils.DeserializeObject(br);

		}
    }
}
