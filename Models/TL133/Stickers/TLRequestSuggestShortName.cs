using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL133.Stickers
{
	[TLObject(1303364867)]
    public class TLRequestSuggestShortName : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return 1303364867;
            }
        }

                public string Title {get;set;}
public Stickers.TLSuggestedShortName Response { get; set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Title = StringUtil.Deserialize(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            StringUtil.Serialize(Title,bw);

        }

		public override void DeserializeResponse(BinaryReader br)
		{
			Response = (Stickers.TLSuggestedShortName)ObjectUtils.DeserializeObject(br);

		}
    }
}
