using System.IO;

namespace TeleNet.Models.TL
{
	[TLObject(-1140172836)]
    public class TLRecentMeUrlStickerSet : TLAbsRecentMeUrl
    {
        public override int Constructor
        {
            get
            {
                return -1140172836;
            }
        }

             public string Url {get;set;}
     public TLAbsStickerSetCovered Set {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Url = StringUtil.Deserialize(br);
Set = (TLAbsStickerSetCovered)ObjectUtils.DeserializeObject(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            StringUtil.Serialize(Url,bw);
ObjectUtils.SerializeObject(Set,bw);

        }
    }
}
