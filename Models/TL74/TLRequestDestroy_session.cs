using System.IO;

namespace TeleNet.Models.TL
{
	[TLObject(-414113498)]
    public class TLRequestDestroy_session : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return -414113498;
            }
        }

                public long SessionId {get;set;}
        public TLAbsDestroySessionRes Response{ get; set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            SessionId = br.ReadInt64();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            bw.Write(SessionId);

        }
		public override void DeserializeResponse(BinaryReader br)
		{
			Response = (TLAbsDestroySessionRes)ObjectUtils.DeserializeObject(br);

		}
    }
}
