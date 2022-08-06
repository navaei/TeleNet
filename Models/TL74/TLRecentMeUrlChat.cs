using System.IO;

namespace TeleNet.Models.TL
{
	[TLObject(-1608834311)]
    public class TLRecentMeUrlChat : TLAbsRecentMeUrl
    {
        public override int Constructor
        {
            get
            {
                return -1608834311;
            }
        }

             public string Url {get;set;}
     public int ChatId {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Url = StringUtil.Deserialize(br);
ChatId = br.ReadInt32();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            StringUtil.Serialize(Url,bw);
bw.Write(ChatId);

        }
    }
}
