using System.IO;

namespace TeleNet.Models.TL.Help
{
	[TLObject(235081943)]
    public class TLRecentMeUrls : TLObject
    {
        public override int Constructor
        {
            get
            {
                return 235081943;
            }
        }

             public TLVector<TLAbsRecentMeUrl> Urls {get;set;}
     public TLVector<TLAbsChat> Chats {get;set;}
     public TLVector<TLAbsUser> Users {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Urls = (TLVector<TLAbsRecentMeUrl>)ObjectUtils.DeserializeVector<TLAbsRecentMeUrl>(br);
Chats = (TLVector<TLAbsChat>)ObjectUtils.DeserializeVector<TLAbsChat>(br);
Users = (TLVector<TLAbsUser>)ObjectUtils.DeserializeVector<TLAbsUser>(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            ObjectUtils.SerializeObject(Urls,bw);
ObjectUtils.SerializeObject(Chats,bw);
ObjectUtils.SerializeObject(Users,bw);

        }
    }
}
