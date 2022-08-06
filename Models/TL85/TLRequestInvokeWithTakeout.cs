using System.IO;

namespace  TeleNet.Models.TL85
{
	[TLObject(-1398145746)]
    public class TLRequestInvokeWithTakeout : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return -1398145746;
            }
        }

                public long TakeoutId {get;set;}
        public TLObject Query {get;set;}
public TLObject Response { get; set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            TakeoutId = br.ReadInt64();
Query = (TLObject)ObjectUtils.DeserializeObject(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            bw.Write(TakeoutId);
ObjectUtils.SerializeObject(Query,bw);

        }

		public override void DeserializeResponse(BinaryReader br)
		{
			Response = (TLObject)ObjectUtils.DeserializeObject(br);

		}
    }
}
