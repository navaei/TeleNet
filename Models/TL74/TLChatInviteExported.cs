using System.IO;

namespace TeleNet.Models.TL
{
	[TLObject(-64092740)]
    public class TLChatInviteExported : TLAbsExportedChatInvite
    {
        public override int Constructor
        {
            get
            {
                return -64092740;
            }
        }

             public string Link {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Link = StringUtil.Deserialize(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            StringUtil.Serialize(Link,bw);

        }
    }
}
