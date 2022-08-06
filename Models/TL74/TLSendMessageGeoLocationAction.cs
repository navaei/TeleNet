using System.IO;

namespace TeleNet.Models.TL
{
    [TLObject(393186209)]
    public class TLSendMessageGeoLocationAction : TLAbsSendMessageAction
    {
        public override int Constructor
        {
            get
            {
                return 393186209;
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
