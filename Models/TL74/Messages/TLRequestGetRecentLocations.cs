using System.IO;

namespace TeleNet.Models.TL.Messages
{
	[TLObject(-1144759543)]
    public class TLRequestGetRecentLocations : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return -1144759543;
            }
        }

                public TLAbsInputPeer Peer {get;set;}
        public int Limit {get;set;}
        public int Hash {get;set;}
        public Messages.TLAbsMessages Response{ get; set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Peer = (TLAbsInputPeer)ObjectUtils.DeserializeObject(br);
Limit = br.ReadInt32();
Hash = br.ReadInt32();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            ObjectUtils.SerializeObject(Peer,bw);
bw.Write(Limit);
bw.Write(Hash);

        }
		public override void DeserializeResponse(BinaryReader br)
		{
			Response = (Messages.TLAbsMessages)ObjectUtils.DeserializeObject(br);

		}
    }
}
