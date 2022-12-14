using System.IO;

namespace TeleNet.Models.TL.Help
{
	[TLObject(1036054804)]
    public class TLRequestGetRecentMeUrls : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return 1036054804;
            }
        }

                public string Referer {get;set;}
        public Help.TLRecentMeUrls Response{ get; set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Referer = StringUtil.Deserialize(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            StringUtil.Serialize(Referer,bw);

        }
		public override void DeserializeResponse(BinaryReader br)
		{
			Response = (Help.TLRecentMeUrls)ObjectUtils.DeserializeObject(br);

		}
    }
}
