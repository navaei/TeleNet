using System.IO;

namespace  TeleNet.Models.TL85.Messages
{
	[TLObject(2119757468)]
    public class TLRequestClearAllDrafts : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return 2119757468;
            }
        }

        public bool Response { get; set;}


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
			Response = BoolUtil.Deserialize(br);

		}
    }
}
