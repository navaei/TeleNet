using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL133
{
	[TLObject(-1294306862)]
    public class TLRecentMeUrlChat : TLAbsRecentMeUrl
    {
        public override int Constructor
        {
            get
            {
                return -1294306862;
            }
        }

             public string Url {get;set;}
     public long ChatId {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Url = StringUtil.Deserialize(br);
ChatId = br.ReadInt64();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            StringUtil.Serialize(Url,bw);
bw.Write(ChatId);

        }
    }
}
