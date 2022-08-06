using System.IO;
using TeleNet.Models.TL;

namespace  TeleNet.Models.TL85.Langpack
{
	[TLObject(-219008246)]
    public class TLRequestGetLangPack : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return -219008246;
            }
        }

                public string LangPack {get;set;}
        public string LangCode {get;set;}
public TLLangPackDifference Response { get; set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            LangPack = StringUtil.Deserialize(br);
LangCode = StringUtil.Deserialize(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            StringUtil.Serialize(LangPack,bw);
StringUtil.Serialize(LangCode,bw);

        }

		public override void DeserializeResponse(BinaryReader br)
		{
			Response = (TLLangPackDifference)ObjectUtils.DeserializeObject(br);

		}
    }
}
