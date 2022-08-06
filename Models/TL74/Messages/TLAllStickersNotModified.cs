using System.IO;
using TeleNet.Models.TL.Messages;

namespace TeleNet.Models.TL.Messages
{
    [TLObject(-395967805)]
    public class TLAllStickersNotModified : TLAbsAllStickers
    {
        public override int Constructor
        {
            get
            {
                return -395967805;
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
