using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace  TeleNet.Models.TL96
{
	[TLObject(1913199744)]
    public class TLInputWallPaperSlug : TLAbsInputWallPaper
    {
        public override int Constructor
        {
            get
            {
                return 1913199744;
            }
        }

             public string Slug {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Slug = StringUtil.Deserialize(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            StringUtil.Serialize(Slug,bw);

        }
    }
}
