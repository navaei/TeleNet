using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL140.Phone
{
	[TLObject(767505458)]
    public class TLGroupCallStreamRtmpUrl : TLObject
    {
        public override int Constructor
        {
            get
            {
                return 767505458;
            }
        }

             public string Url {get;set;}
     public string Key {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Url = StringUtil.Deserialize(br);
Key = StringUtil.Deserialize(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            StringUtil.Serialize(Url,bw);
StringUtil.Serialize(Key,bw);

        }
    }
}
