using System.IO;

namespace TeleNet.Models.TL
{
	[TLObject(-368010477)]
    public class TLDestroy_auth_key_fail : TLAbsDestroyAuthKeyRes
    {
        public override int Constructor
        {
            get
            {
                return -368010477;
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
