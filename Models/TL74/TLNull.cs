using System.IO;

namespace TeleNet.Models.TL
{
    [TLObject(1450380236)]
    public class TLNull : TLObject
    {
        public override int Constructor
        {
            get
            {
                return 1450380236;
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
