using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL133.Account
{
	[TLObject(-690545285)]
    public class TLRequestGetChatThemes : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return -690545285;
            }
        }

                public int Hash {get;set;}
public Account.TLAbsChatThemes Response { get; set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Hash = br.ReadInt32();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            bw.Write(Hash);

        }

		public override void DeserializeResponse(BinaryReader br)
		{
			Response = (Account.TLAbsChatThemes)ObjectUtils.DeserializeObject(br);

		}
    }
}
