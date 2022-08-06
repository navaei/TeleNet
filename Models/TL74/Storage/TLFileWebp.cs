using System.IO;
using TeleNet.Models.TL.Storage;

namespace TeleNet.Models.TL.Storage
{
    [TLObject(276907596)]
    public class TLFileWebp : TLAbsFileType
    {
        public override int Constructor
        {
            get
            {
                return 276907596;
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
