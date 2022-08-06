using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace  TeleNet.Models.TL96
{
	[TLObject(-454524911)]
    public class TLPageBlockList : TLAbsPageBlock
    {
        public override int Constructor
        {
            get
            {
                return -454524911;
            }
        }

             public TLVector<TLAbsPageListItem> Items {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Items = (TLVector<TLAbsPageListItem>)ObjectUtils.DeserializeVector<TLAbsPageListItem>(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            ObjectUtils.SerializeObject(Items,bw);

        }
    }
}
