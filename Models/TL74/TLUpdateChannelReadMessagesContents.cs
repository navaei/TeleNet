using System.IO;

namespace TeleNet.Models.TL
{
	[TLObject(-1987495099)]
    public class TLUpdateChannelReadMessagesContents : TLAbsUpdate
    {
        public override int Constructor
        {
            get
            {
                return -1987495099;
            }
        }

             public int ChannelId {get;set;}
     public TLVector<int> Messages {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            ChannelId = br.ReadInt32();
Messages = (TLVector<int>)ObjectUtils.DeserializeVector<int>(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            bw.Write(ChannelId);
ObjectUtils.SerializeObject(Messages,bw);

        }
    }
}
