using System.IO;

namespace  TeleNet.Models.TL85
{
    [TLObject(-1370486635)]
    public class TLFutureSalts : TLObject
    {
        public override int Constructor
        {
            get
            {
                return -1370486635;
            }
        }

        public long ReqMsgId { get; set; }
        public int Now { get; set; }
        public TLVector<TLFutureSalt> Salts { get; set; }

        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            ReqMsgId = br.ReadInt64();
            Now = br.ReadInt32();
            Salts = (TLVector<TLFutureSalt>)ObjectUtils.DeserializeVector<TLFutureSalt>(br);
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(ReqMsgId);
            bw.Write(Now);
            ObjectUtils.SerializeObject(Salts, bw);

        }
    }
}
