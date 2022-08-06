using System.IO;

namespace TeleNet.Models.TL
{
	[TLObject(1491380032)]
    public class TLRequestRpc_drop_answer : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return 1491380032;
            }
        }

                public long ReqMsgId {get;set;}
        public TLAbsRpcDropAnswer Response{ get; set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            ReqMsgId = br.ReadInt64();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            bw.Write(ReqMsgId);

        }
		public override void DeserializeResponse(BinaryReader br)
		{
			Response = (TLAbsRpcDropAnswer)ObjectUtils.DeserializeObject(br);

		}
    }
}
