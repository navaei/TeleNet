using System.IO;

namespace TeleNet.Models.TL.Messages
{
    [TLObject(1259113487)]
    public class TLRequestReportEncryptedSpam : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return 1259113487;
            }
        }

        public TLInputEncryptedChat Peer { get; set; }
        public bool Response { get; set; }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Peer = (TLInputEncryptedChat)ObjectUtils.DeserializeObject(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ObjectUtils.SerializeObject(Peer, bw);

        }
        public override void DeserializeResponse(BinaryReader br)
        {
            Response = BoolUtil.Deserialize(br);

        }
    }
}
