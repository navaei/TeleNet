using System.IO;

namespace TeleNet.Models.TL.Messages
{
	[TLObject(585256482)]
    public class TLRequestGetDialogUnreadMarks : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return 585256482;
            }
        }

                public TLVector<TLDialogPeer> Response{ get; set;}


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
		public override void DeserializeResponse(BinaryReader br)
		{
			Response = (TLVector<TLDialogPeer>)ObjectUtils.DeserializeVector<TLDialogPeer>(br);

		}
    }
}
