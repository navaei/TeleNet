using System.IO;

namespace TeleNet.Models.TL
{
    [TLObject(608050278)]
    public class TLSendMessageUploadRoundAction : TLAbsSendMessageAction
    {
        public override int Constructor
        {
            get
            {
                return 608050278;
            }
        }

        public int Progress { get; set; }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Progress = br.ReadInt32();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(Progress);

        }
    }
}
