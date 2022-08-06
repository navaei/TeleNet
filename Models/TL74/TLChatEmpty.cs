using System.IO;

namespace TeleNet.Models.TL
{
	[TLObject(-1683826688)]
    public class TLChatEmpty : TLAbsChat
    {
        public override int Constructor
        {
            get
            {
                return -1683826688;
            }
        }


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Id = br.ReadInt32();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            bw.Write(Id);

        }
    }
}
