using System.IO;
using TeleNet.Models.TL;

namespace  TeleNet.Models.TL85
{
    [TLObject(700340377)]
    public class TLInputTakeoutFileLocation : TLAbsInputFileLocation
    {
        public override int Constructor
        {
            get
            {
                return 700340377;
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
