using System.IO;

namespace TeleNet.Models.TL
{
	[TLObject(-1188971260)]
    public class TLRequestGet_future_salts : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return -1188971260;
            }
        }

                public int Num {get;set;}
        public TLFuture_salts Response{ get; set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Num = br.ReadInt32();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            bw.Write(Num);

        }
		public override void DeserializeResponse(BinaryReader br)
		{
			Response = (TLFuture_salts)ObjectUtils.DeserializeObject(br);

		}
    }
}
