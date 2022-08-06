using System.IO;

namespace TeleNet.Models.TL
{
	[TLObject(-1631450872)]
    public class TLNew_session_created : TLObject
    {
        public override int Constructor
        {
            get
            {
                return -1631450872;
            }
        }

             public long FirstMsgId {get;set;}
     public long UniqueId {get;set;}
     public long ServerSalt {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            FirstMsgId = br.ReadInt64();
UniqueId = br.ReadInt64();
ServerSalt = br.ReadInt64();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            bw.Write(FirstMsgId);
bw.Write(UniqueId);
bw.Write(ServerSalt);

        }
    }
}
