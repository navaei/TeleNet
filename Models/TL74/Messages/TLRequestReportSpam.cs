using System.IO;

namespace TeleNet.Models.TL.Messages
{
    [TLObject(-820669733)]
    public class TLRequestReportSpam : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return -820669733;
            }
        }

        public TLAbsInputPeer Peer { get; set; }
        public bool Response { get; set; }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Peer = (TLAbsInputPeer)ObjectUtils.DeserializeObject(br);

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
