using System.IO;

namespace TeleNet.Models.TL.Help
{
	[TLObject(1722786150)]
    public class TLDeepLinkInfoEmpty : TLAbsDeepLinkInfo
    {
        public override int Constructor
        {
            get
            {
                return 1722786150;
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
