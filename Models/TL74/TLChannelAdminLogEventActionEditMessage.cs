using System.IO;

namespace TeleNet.Models.TL
{
	[TLObject(1889215493)]
    public class TLChannelAdminLogEventActionEditMessage : TLAbsChannelAdminLogEventAction
    {
        public override int Constructor
        {
            get
            {
                return 1889215493;
            }
        }

             public TLAbsMessage PrevMessage {get;set;}
     public TLAbsMessage NewMessage {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            PrevMessage = (TLAbsMessage)ObjectUtils.DeserializeObject(br);
NewMessage = (TLAbsMessage)ObjectUtils.DeserializeObject(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            ObjectUtils.SerializeObject(PrevMessage,bw);
ObjectUtils.SerializeObject(NewMessage,bw);

        }
    }
}
