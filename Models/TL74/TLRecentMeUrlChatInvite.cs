using System.IO;

namespace TeleNet.Models.TL
{
	[TLObject(-347535331)]
    public class TLRecentMeUrlChatInvite : TLAbsRecentMeUrl
    {
        public override int Constructor
        {
            get
            {
                return -347535331;
            }
        }

             public string Url {get;set;}
     public TLAbsChatInvite ChatInvite {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Url = StringUtil.Deserialize(br);
ChatInvite = (TLAbsChatInvite)ObjectUtils.DeserializeObject(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            StringUtil.Serialize(Url,bw);
ObjectUtils.SerializeObject(ChatInvite,bw);

        }
    }
}
