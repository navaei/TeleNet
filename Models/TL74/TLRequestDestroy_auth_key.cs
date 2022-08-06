using System.IO;

namespace TeleNet.Models.TL
{
	[TLObject(-784117408)]
    public class TLRequestDestroy_auth_key : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return -784117408;
            }
        }

                public TLAbsDestroyAuthKeyRes Response{ get; set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            
        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            
        }
		public override void DeserializeResponse(BinaryReader br)
		{
			Response = (TLAbsDestroyAuthKeyRes)ObjectUtils.DeserializeObject(br);

		}
    }
}
