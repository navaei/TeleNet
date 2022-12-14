using System.IO;

namespace TeleNet.Models.TL
{
    [TLObject(-2095595325)]
    public class TLUpdateBotWebhookJSON : TLAbsUpdate
    {
        public override int Constructor
        {
            get
            {
                return -2095595325;
            }
        }

        public TLDataJSON Data { get; set; }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Data = (TLDataJSON)ObjectUtils.DeserializeObject(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ObjectUtils.SerializeObject(Data, bw);

        }
    }
}
