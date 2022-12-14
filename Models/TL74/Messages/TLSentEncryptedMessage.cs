using System.IO;
using TeleNet.Models.TL.Messages;

namespace TeleNet.Models.TL.Messages
{
    [TLObject(1443858741)]
    public class TLSentEncryptedMessage : TLAbsSentEncryptedMessage
    {
        public override int Constructor
        {
            get
            {
                return 1443858741;
            }
        }

        public int Date { get; set; }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Date = br.ReadInt32();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(Date);

        }
    }
}
