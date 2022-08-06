using System.IO;

namespace TeleNet.Models.TL
{
	[TLObject(-213746804)]
    public class TLRequestPing_delay_disconnect : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return -213746804;
            }
        }

                public long PingId {get;set;}
        public int DisconnectDelay {get;set;}
        public TLPong Response{ get; set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            PingId = br.ReadInt64();
DisconnectDelay = br.ReadInt32();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            bw.Write(PingId);
bw.Write(DisconnectDelay);

        }
		public override void DeserializeResponse(BinaryReader br)
		{
			Response = (TLPong)ObjectUtils.DeserializeObject(br);

		}
    }
}
