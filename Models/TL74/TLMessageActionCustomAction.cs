using System.IO;

namespace TeleNet.Models.TL
{
	[TLObject(-85549226)]
    public class TLMessageActionCustomAction : TLAbsMessageAction
    {
        public override int Constructor
        {
            get
            {
                return -85549226;
            }
        }

             public string Message {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Message = StringUtil.Deserialize(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            StringUtil.Serialize(Message,bw);

        }
    }
}
