using System.IO;

namespace TeleNet.Models.TL
{
	[TLObject(2059302892)]
    public class TLRequestPing : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return 2059302892;
            }
        }

                public long PingId {get;set;}
        public TLPong Response{ get; set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            PingId = br.ReadInt64();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            bw.Write(PingId);

        }
		public override void DeserializeResponse(BinaryReader br)
		{
			Response = (TLPong)ObjectUtils.DeserializeObject(br);

		}
    }
}
