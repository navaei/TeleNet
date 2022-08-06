using System.IO;

namespace TeleNet.Models.TL
{
	[TLObject(178201177)]
    public class TLDestroy_auth_key_none : TLAbsDestroyAuthKeyRes
    {
        public override int Constructor
        {
            get
            {
                return 178201177;
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
