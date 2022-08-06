using System.IO;

namespace TeleNet.Models.TL
{
	[TLObject(-1160714821)]
    public class TLPeerChat : TLAbsPeer
    {
        public override int Constructor
        {
            get
            {
                return -1160714821;
            }
        }

             public int ChatId {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            ChatId = br.ReadInt32();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            bw.Write(ChatId);

        }
    }
}
