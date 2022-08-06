using System.IO;
using TeleNet.Models.TL;

namespace  TeleNet.Models.TL85
{
    [TLObject(-1160215659)]
    public class TLInputMessageReplyTo : TLAbsInputMessage
    {
        public override int Constructor
        {
            get
            {
                return -1160215659;
            }
        }

        public int Id { get; set; }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Id = br.ReadInt32();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(Id);

        }
    }
}
