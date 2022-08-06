using System.IO;

namespace TeleNet.Models.TL
{
	[TLObject(872932635)]
    public class TLStickerSetMultiCovered : TLAbsStickerSetCovered
    {
        public override int Constructor
        {
            get
            {
                return 872932635;
            }
        }

             public TLStickerSet Set {get;set;}
     public TLVector<TLAbsDocument> Covers {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Set = (TLStickerSet)ObjectUtils.DeserializeObject(br);
Covers = (TLVector<TLAbsDocument>)ObjectUtils.DeserializeVector<TLAbsDocument>(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            ObjectUtils.SerializeObject(Set,bw);
ObjectUtils.SerializeObject(Covers,bw);

        }
    }
}
