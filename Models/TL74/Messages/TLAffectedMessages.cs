using System.IO;

namespace TeleNet.Models.TL.Messages
{
    [TLObject(-2066640507)]
    public class TLAffectedMessages : TLObject
    {
        public override int Constructor
        {
            get
            {
                return -2066640507;
            }
        }

        public int Pts { get; set; }
        public int PtsCount { get; set; }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Pts = br.ReadInt32();
            PtsCount = br.ReadInt32();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(Pts);
            bw.Write(PtsCount);

        }
    }
}
