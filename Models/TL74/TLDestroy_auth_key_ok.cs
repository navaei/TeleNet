using System.IO;

namespace TeleNet.Models.TL
{
	[TLObject(-161422892)]
    public class TLDestroy_auth_key_ok : TLAbsDestroyAuthKeyRes
    {
        public override int Constructor
        {
            get
            {
                return -161422892;
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
