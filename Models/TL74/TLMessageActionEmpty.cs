using System.IO;

namespace TeleNet.Models.TL
{
    [TLObject(-1230047312)]
    public class TLMessageActionEmpty : TLAbsMessageAction
    {
        public override int Constructor
        {
            get
            {
                return -1230047312;
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
