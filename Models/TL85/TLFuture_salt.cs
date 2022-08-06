using System.IO;

namespace  TeleNet.Models.TL85
{
    [TLObject(155834844)]
    public class TLFutureSalt : TLObject
    {
        public override int Constructor
        {
            get
            {
                return 155834844;
            }
        }

        public int ValidSince { get; set; }
        public int ValidUntil { get; set; }
        public long Salt { get; set; }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            ValidSince = br.ReadInt32();
            ValidUntil = br.ReadInt32();
            Salt = br.ReadInt64();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(ValidSince);
            bw.Write(ValidUntil);
            bw.Write(Salt);

        }
    }
}
