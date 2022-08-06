using System.IO;

namespace TeleNet.Models.TL
{
	[TLObject(-847714938)]
    public class TLRpc_answer_dropped_running : TLAbsRpcDropAnswer
    {
        public override int Constructor
        {
            get
            {
                return -847714938;
            }
        }

        

		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            
        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            
        }
    }
}
