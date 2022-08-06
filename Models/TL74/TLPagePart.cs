using System.IO;

namespace TeleNet.Models.TL
{
	[TLObject(-1908433218)]
    public class TLPagePart : TLAbsPage
    {
        public override int Constructor
        {
            get
            {
                return -1908433218;
            }
        }

             public TLVector<TLAbsPageBlock> Blocks {get;set;}
     public TLVector<TLAbsPhoto> Photos {get;set;}
     public TLVector<TLAbsDocument> Documents {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Blocks = (TLVector<TLAbsPageBlock>)ObjectUtils.DeserializeVector<TLAbsPageBlock>(br);
Photos = (TLVector<TLAbsPhoto>)ObjectUtils.DeserializeVector<TLAbsPhoto>(br);
Documents = (TLVector<TLAbsDocument>)ObjectUtils.DeserializeVector<TLAbsDocument>(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            ObjectUtils.SerializeObject(Blocks,bw);
ObjectUtils.SerializeObject(Photos,bw);
ObjectUtils.SerializeObject(Documents,bw);

        }
    }
}
