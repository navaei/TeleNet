using System.IO;

namespace  TeleNet.Models.TL85.Help
{
    [TLObject(1515793004)]
    public class TLConfigSimple : TLObject
    {
        public override int Constructor
        {
            get
            {
                return 1515793004;
            }
        }

        public int Date { get; set; }
        public int Expires { get; set; }
        public TLVector<TL.TLAccessPointRule> Rules { get; set; }

        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Date = br.ReadInt32();
            Expires = br.ReadInt32();
            Rules = ObjectUtils.DeserializeVector<TL.TLAccessPointRule>(br);
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(Date);
            bw.Write(Expires);
            ObjectUtils.SerializeObject(Rules, bw);

        }
    }
}
