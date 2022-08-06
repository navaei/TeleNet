using System.IO;

namespace TeleNet.Models.TL
{
	[TLObject(1189204285)]
    public class TLRecentMeUrlUnknown : TLAbsRecentMeUrl
    {
        public override int Constructor
        {
            get
            {
                return 1189204285;
            }
        }

             public string Url {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Url = StringUtil.Deserialize(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            StringUtil.Serialize(Url,bw);

        }
    }
}
