using System.IO;

namespace TeleNet.Models.TL
{
	[TLObject(-1670052855)]
    public class TLFoundGifCached : TLAbsFoundGif
    {
        public override int Constructor
        {
            get
            {
                return -1670052855;
            }
        }

             public string Url {get;set;}
     public TLAbsPhoto Photo {get;set;}
     public TLAbsDocument Document {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Url = StringUtil.Deserialize(br);
Photo = (TLAbsPhoto)ObjectUtils.DeserializeObject(br);
Document = (TLAbsDocument)ObjectUtils.DeserializeObject(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            StringUtil.Serialize(Url,bw);
ObjectUtils.SerializeObject(Photo,bw);
ObjectUtils.SerializeObject(Document,bw);

        }
    }
}
