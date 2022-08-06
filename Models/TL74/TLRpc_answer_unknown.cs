using System.IO;

namespace TeleNet.Models.TL
{
	[TLObject(1579864942)]
    public class TLRpc_answer_unknown : TLAbsRpcDropAnswer
    {
        public override int Constructor
        {
            get
            {
                return 1579864942;
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
