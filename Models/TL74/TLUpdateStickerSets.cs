using System.IO;

namespace TeleNet.Models.TL
{
    [TLObject(1135492588)]
    public class TLUpdateStickerSets : TLAbsUpdate
    {
        public override int Constructor
        {
            get
            {
                return 1135492588;
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
