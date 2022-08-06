using System.IO;

namespace TeleNet.Models.TL
{
	[TLObject(2105940488)]
    public class TLMsg_resend_req : TLObject
    {
        public override int Constructor
        {
            get
            {
                return 2105940488;
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
