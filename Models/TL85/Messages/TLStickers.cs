using System.IO;
using TeleNet.Models.TL;
using TeleNet.Models.TL.Messages;

namespace  TeleNet.Models.TL85.Messages
{
	[TLObject(-463889475)]
    public class TLStickers : TLAbsStickers
    {
        public override int Constructor
        {
            get
            {
                return -463889475;
            }
        }

             public int Hash {get;set;}
     public TLVector<TLAbsDocument> Stickers {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Hash = br.ReadInt32();
Stickers = (TLVector<TLAbsDocument>)ObjectUtils.DeserializeVector<TLAbsDocument>(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            bw.Write(Hash);
ObjectUtils.SerializeObject(Stickers,bw);

        }
    }
}
