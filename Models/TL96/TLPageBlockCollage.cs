using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace  TeleNet.Models.TL96
{
	[TLObject(1705048653)]
    public class TLPageBlockCollage : TLAbsPageBlock
    {
        public override int Constructor
        {
            get
            {
                return 1705048653;
            }
        }

             public TLVector<TLAbsPageBlock> Items {get;set;}
     public TLPageCaption Caption {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Items = (TLVector<TLAbsPageBlock>)ObjectUtils.DeserializeVector<TLAbsPageBlock>(br);
Caption = (TLPageCaption)ObjectUtils.DeserializeObject(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            ObjectUtils.SerializeObject(Items,bw);
ObjectUtils.SerializeObject(Caption,bw);

        }
    }
}
