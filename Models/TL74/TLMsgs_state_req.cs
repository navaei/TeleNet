using System.IO;

namespace TeleNet.Models.TL
{
	[TLObject(-630588590)]
    public class TLMsgs_state_req : TLObject
    {
        public override int Constructor
        {
            get
            {
                return -630588590;
            }
        }

             public TLVector<long> MsgIds {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            MsgIds = (TLVector<long>)ObjectUtils.DeserializeVector<long>(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            ObjectUtils.SerializeObject(MsgIds,bw);

        }
    }
}
