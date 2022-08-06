using System.IO;

namespace TeleNet.Models.TL
{
	[TLObject(-1370486635)]
    public class TLFuture_salts : TLObject
    {
        public override int Constructor
        {
            get
            {
                return -1370486635;
            }
        }

             public long ReqMsgId {get;set;}
     public int Now {get;set;}
     public TLVector<TLFuture_salt> Salts {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            ReqMsgId = br.ReadInt64();
Now = br.ReadInt32();
Salts = (TLVector<TLFuture_salt>)ObjectUtils.DeserializeVector<TLFuture_salt>(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            bw.Write(ReqMsgId);
bw.Write(Now);
ObjectUtils.SerializeObject(Salts,bw);

        }
    }
}
