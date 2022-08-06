using System.IO;

namespace TeleNet.Models.TL.Channels
{
	[TLObject(-1355375294)]
    public class TLRequestDeleteHistory : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return -1355375294;
            }
        }

                public TLAbsInputChannel Channel {get;set;}
        public int MaxId {get;set;}
        public bool Response{ get; set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Channel = (TLAbsInputChannel)ObjectUtils.DeserializeObject(br);
MaxId = br.ReadInt32();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            ObjectUtils.SerializeObject(Channel,bw);
bw.Write(MaxId);

        }
		public override void DeserializeResponse(BinaryReader br)
		{
			Response = BoolUtil.Deserialize(br);

		}
    }
}
