using System.IO;

namespace TeleNet.Models.TL.Messages
{
	[TLObject(251759059)]
    public class TLRequestReadMentions : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return 251759059;
            }
        }

                public TLAbsInputPeer Peer {get;set;}
        public Messages.TLAffectedHistory Response{ get; set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Peer = (TLAbsInputPeer)ObjectUtils.DeserializeObject(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            ObjectUtils.SerializeObject(Peer,bw);

        }
		public override void DeserializeResponse(BinaryReader br)
		{
			Response = (Messages.TLAffectedHistory)ObjectUtils.DeserializeObject(br);

		}
    }
}
