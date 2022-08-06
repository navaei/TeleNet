using System.IO;

namespace TeleNet.Models.TL
{
	[TLObject(880243653)]
    public class TLPong : TLObject
    {
        public override int Constructor
        {
            get
            {
                return 880243653;
            }
        }

             public long MsgId {get;set;}
     public long PingId {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            MsgId = br.ReadInt64();
PingId = br.ReadInt64();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            bw.Write(MsgId);
bw.Write(PingId);

        }
    }
}
