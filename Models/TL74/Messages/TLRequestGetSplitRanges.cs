using System.IO;

namespace TeleNet.Models.TL.Messages
{
	[TLObject(486505992)]
    public class TLRequestGetSplitRanges : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return 486505992;
            }
        }

                public TLVector<TLMessageRange> Response{ get; set;}


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
			Response = (TLVector<TLMessageRange>)ObjectUtils.DeserializeVector<TLMessageRange>(br);

		}
    }
}
