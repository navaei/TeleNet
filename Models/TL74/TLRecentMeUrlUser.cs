using System.IO;

namespace TeleNet.Models.TL
{
	[TLObject(-1917045962)]
    public class TLRecentMeUrlUser : TLAbsRecentMeUrl
    {
        public override int Constructor
        {
            get
            {
                return -1917045962;
            }
        }

             public string Url {get;set;}
     public int UserId {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Url = StringUtil.Deserialize(br);
UserId = br.ReadInt32();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            StringUtil.Serialize(Url,bw);
bw.Write(UserId);

        }
    }
}
