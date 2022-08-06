using System.IO;

namespace TeleNet.Models.TL.Channels
{
	[TLObject(-359881479)]
    public class TLRequestSetStickers : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return -359881479;
            }
        }

                public TLAbsInputChannel Channel {get;set;}
        public TLAbsInputStickerSet Stickerset {get;set;}
        public bool Response{ get; set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Channel = (TLAbsInputChannel)ObjectUtils.DeserializeObject(br);
Stickerset = (TLAbsInputStickerSet)ObjectUtils.DeserializeObject(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            ObjectUtils.SerializeObject(Channel,bw);
ObjectUtils.SerializeObject(Stickerset,bw);

        }
		public override void DeserializeResponse(BinaryReader br)
		{
			Response = BoolUtil.Deserialize(br);

		}
    }
}
