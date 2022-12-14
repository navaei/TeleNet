using System.IO;

namespace TeleNet.Models.TL.Channels
{
	[TLObject(-357180360)]
    public class TLRequestReadMessageContents : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return -357180360;
            }
        }

                public TLAbsInputChannel Channel {get;set;}
        public TLVector<int> Id {get;set;}
        public bool Response{ get; set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Channel = (TLAbsInputChannel)ObjectUtils.DeserializeObject(br);
Id = (TLVector<int>)ObjectUtils.DeserializeVector<int>(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            ObjectUtils.SerializeObject(Channel,bw);
ObjectUtils.SerializeObject(Id,bw);

        }
		public override void DeserializeResponse(BinaryReader br)
		{
			Response = BoolUtil.Deserialize(br);

		}
    }
}
