using System.IO;

namespace TeleNet.Models.TL
{
	[TLObject(1678812626)]
    public class TLStickerSetCovered : TLAbsStickerSetCovered
    {
        public override int Constructor
        {
            get
            {
                return 1678812626;
            }
        }

             public TLStickerSet Set {get;set;}
     public TLAbsDocument Cover {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Set = (TLStickerSet)ObjectUtils.DeserializeObject(br);
Cover = (TLAbsDocument)ObjectUtils.DeserializeObject(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            ObjectUtils.SerializeObject(Set,bw);
ObjectUtils.SerializeObject(Cover,bw);

        }
    }
}
