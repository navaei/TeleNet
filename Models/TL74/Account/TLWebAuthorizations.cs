using System.IO;

namespace TeleNet.Models.TL.Account
{
	[TLObject(-313079300)]
    public class TLWebAuthorizations : TLObject
    {
        public override int Constructor
        {
            get
            {
                return -313079300;
            }
        }

             public TLVector<TLWebAuthorization> Authorizations {get;set;}
     public TLVector<TLAbsUser> Users {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Authorizations = (TLVector<TLWebAuthorization>)ObjectUtils.DeserializeVector<TLWebAuthorization>(br);
Users = (TLVector<TLAbsUser>)ObjectUtils.DeserializeVector<TLAbsUser>(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            ObjectUtils.SerializeObject(Authorizations,bw);
ObjectUtils.SerializeObject(Users,bw);

        }
    }
}
