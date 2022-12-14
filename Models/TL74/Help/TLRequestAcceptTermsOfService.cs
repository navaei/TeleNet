using System.IO;

namespace TeleNet.Models.TL.Help
{
	[TLObject(-294455398)]
    public class TLRequestAcceptTermsOfService : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return -294455398;
            }
        }

                public TLDataJSON Id {get;set;}
        public bool Response{ get; set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Id = (TLDataJSON)ObjectUtils.DeserializeObject(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            ObjectUtils.SerializeObject(Id,bw);

        }
		public override void DeserializeResponse(BinaryReader br)
		{
			Response = BoolUtil.Deserialize(br);

		}
    }
}
