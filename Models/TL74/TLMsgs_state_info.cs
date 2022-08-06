using System.IO;

namespace TeleNet.Models.TL
{
	[TLObject(81704317)]
    public class TLMsgs_state_info : TLObject
    {
        public override int Constructor
        {
            get
            {
                return 81704317;
            }
        }

             public long ReqMsgId {get;set;}
     public string Info {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            ReqMsgId = br.ReadInt64();
Info = StringUtil.Deserialize(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            bw.Write(ReqMsgId);
StringUtil.Serialize(Info,bw);

        }
    }
}
