using System.IO;

namespace TeleNet.Models.TL
{
	[TLObject(-1539647305)]
    public class TLRpc_answer_dropped : TLAbsRpcDropAnswer
    {
        public override int Constructor
        {
            get
            {
                return -1539647305;
            }
        }

             public long MsgId {get;set;}
     public int SeqNo {get;set;}
     public int Bytes {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            MsgId = br.ReadInt64();
SeqNo = br.ReadInt32();
Bytes = br.ReadInt32();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            bw.Write(MsgId);
bw.Write(SeqNo);
bw.Write(Bytes);

        }
    }
}
