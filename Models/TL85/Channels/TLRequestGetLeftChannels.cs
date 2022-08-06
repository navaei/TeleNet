using System.IO;

namespace  TeleNet.Models.TL85.Channels
{
	[TLObject(-2092831552)]
    public class TLRequestGetLeftChannels : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return -2092831552;
            }
        }

                public int Offset {get;set;}
public TeleNet.Models.TL.Messages.TLAbsChats Response { get; set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Offset = br.ReadInt32();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            bw.Write(Offset);

        }

		public override void DeserializeResponse(BinaryReader br)
		{
			Response = (TeleNet.Models.TL.Messages.TLAbsChats)ObjectUtils.DeserializeObject(br);

		}
    }
}
