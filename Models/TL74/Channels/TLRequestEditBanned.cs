using System.IO;

namespace TeleNet.Models.TL.Channels
{
	[TLObject(-1076292147)]
    public class TLRequestEditBanned : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return -1076292147;
            }
        }

                public TLAbsInputChannel Channel {get;set;}
        public TLAbsInputUser UserId {get;set;}
        public TLChannelBannedRights BannedRights {get;set;}
        public TLAbsUpdates Response{ get; set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Channel = (TLAbsInputChannel)ObjectUtils.DeserializeObject(br);
UserId = (TLAbsInputUser)ObjectUtils.DeserializeObject(br);
BannedRights = (TLChannelBannedRights)ObjectUtils.DeserializeObject(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            ObjectUtils.SerializeObject(Channel,bw);
ObjectUtils.SerializeObject(UserId,bw);
ObjectUtils.SerializeObject(BannedRights,bw);

        }
		public override void DeserializeResponse(BinaryReader br)
		{
			Response = (TLAbsUpdates)ObjectUtils.DeserializeObject(br);

		}
    }
}
