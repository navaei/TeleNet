using System.IO;

namespace TeleNet.Models.TL
{
    [TLObject(2107670217)]
    public class TLInputPeerSelf : TLAbsInputPeer
    {
        public override int Constructor
        {
            get
            {
                return 2107670217;
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
