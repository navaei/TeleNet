using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace  TeleNet.Models.TL111.Payments
{
	[TLObject(1042605427)]
    public class TLBankCardData : TLObject
    {
        public override int Constructor
        {
            get
            {
                return 1042605427;
            }
        }

             public string Title {get;set;}
     public TLVector<TLBankCardOpenUrl> OpenUrls {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Title = StringUtil.Deserialize(br);
OpenUrls = (TLVector<TLBankCardOpenUrl>)ObjectUtils.DeserializeVector<TLBankCardOpenUrl>(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            StringUtil.Serialize(Title,bw);
ObjectUtils.SerializeObject(OpenUrls,bw);

        }
    }
}
