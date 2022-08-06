using System.IO;

namespace  TeleNet.Models.TL85.Messages
{
	[TLObject(71126828)]
    public class TLRequestGetStickers : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return 71126828;
            }
        }

                public string Emoticon {get;set;}
        public int Hash {get;set;}
public TeleNet.Models.TL.Messages.TLAbsStickers Response { get; set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Emoticon = StringUtil.Deserialize(br);
Hash = br.ReadInt32();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            StringUtil.Serialize(Emoticon,bw);
bw.Write(Hash);

        }

		public override void DeserializeResponse(BinaryReader br)
		{
			Response = (TeleNet.Models.TL.Messages.TLAbsStickers)ObjectUtils.DeserializeObject(br);

		}
    }
}
