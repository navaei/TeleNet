using System.IO;

namespace TeleNet.Models.TL
{
	[TLObject(-2137147681)]
    public class TLMsg_new_detailed_info : TLAbsMsgDetailedInfo
    {
        public override int Constructor
        {
            get
            {
                return -2137147681;
            }
        }

             public long AnswerMsgId {get;set;}
     public int Bytes {get;set;}
     public int Status {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            AnswerMsgId = br.ReadInt64();
Bytes = br.ReadInt32();
Status = br.ReadInt32();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            bw.Write(AnswerMsgId);
bw.Write(Bytes);
bw.Write(Status);

        }
    }
}
