using System.IO;

namespace TeleNet.Models.TL.Channels
{
	[TLObject(-309659827)]
    public class TLAdminLogResults : TLObject
    {
        public override int Constructor
        {
            get
            {
                return -309659827;
            }
        }

             public TLVector<TLChannelAdminLogEvent> Events {get;set;}
     public TLVector<TLAbsChat> Chats {get;set;}
     public TLVector<TLAbsUser> Users {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Events = (TLVector<TLChannelAdminLogEvent>)ObjectUtils.DeserializeVector<TLChannelAdminLogEvent>(br);
Chats = (TLVector<TLAbsChat>)ObjectUtils.DeserializeVector<TLAbsChat>(br);
Users = (TLVector<TLAbsUser>)ObjectUtils.DeserializeVector<TLAbsUser>(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            ObjectUtils.SerializeObject(Events,bw);
ObjectUtils.SerializeObject(Chats,bw);
ObjectUtils.SerializeObject(Users,bw);

        }
    }
}
