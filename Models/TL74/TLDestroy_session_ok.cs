using System.IO;

namespace TeleNet.Models.TL
{
	[TLObject(-501201412)]
    public class TLDestroy_session_ok : TLAbsDestroySessionRes
    {
        public override int Constructor
        {
            get
            {
                return -501201412;
            }
        }

             public long SessionId {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            SessionId = br.ReadInt64();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            bw.Write(SessionId);

        }
    }
}
