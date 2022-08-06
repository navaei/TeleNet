using System.IO;
using TeleNet.Models.TL;

namespace  TeleNet.Models.TL85.Messages
{
    [TLObject(-1115507112)]
    public class TLRequestReport : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return -1115507112;
            }
        }

        public TLAbsInputPeer Peer { get; set; }
        public TLVector<int> Id { get; set; }
        public TLAbsReportReason Reason { get; set; }
        public bool Response { get; set; }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Peer = (TLAbsInputPeer)ObjectUtils.DeserializeObject(br);
            Id = (TLVector<int>)ObjectUtils.DeserializeVector<int>(br);
            Reason = (TLAbsReportReason)ObjectUtils.DeserializeObject(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ObjectUtils.SerializeObject(Peer, bw);
            ObjectUtils.SerializeObject(Id, bw);
            ObjectUtils.SerializeObject(Reason, bw);

        }

        public override void DeserializeResponse(BinaryReader br)
        {
            Response = BoolUtil.Deserialize(br);

        }
    }
}
