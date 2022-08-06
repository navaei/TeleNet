using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL133
{
	[TLObject(-1188296222)]
    public class TLRecentMeUrlUser : TLAbsRecentMeUrl
    {
        public override int Constructor
        {
            get
            {
                return -1188296222;
            }
        }

             public string Url {get;set;}
     public long UserId {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Url = StringUtil.Deserialize(br);
UserId = br.ReadInt64();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            StringUtil.Serialize(Url,bw);
bw.Write(UserId);

        }
    }
}
