using System.IO;

namespace TeleNet.Models.TL.Messages
{
	[TLObject(1359533640)]
    public class TLFoundStickerSets : TLAbsFoundStickerSets
    {
        public override int Constructor
        {
            get
            {
                return 1359533640;
            }
        }

             public int Hash {get;set;}
     public TLVector<TLAbsStickerSetCovered> Sets {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Hash = br.ReadInt32();
Sets = (TLVector<TLAbsStickerSetCovered>)ObjectUtils.DeserializeVector<TLAbsStickerSetCovered>(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            bw.Write(Hash);
ObjectUtils.SerializeObject(Sets,bw);

        }
    }
}
