using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL133.Messages
{
    [TLObject(-1991005362)]
    public class TLRequestReport : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return -1991005362;
            }
        }

        public TLAbsInputPeer Peer { get; set; }
        public TLVector<int> Id { get; set; }
        public TLAbsReportReason Reason { get; set; }
        public string Message { get; set; }
        public bool Response { get; set; }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Peer = (TLAbsInputPeer)ObjectUtils.DeserializeObject(br);
            Id = (TLVector<int>)ObjectUtils.DeserializeVector<int>(br);
            Reason = (TLAbsReportReason)ObjectUtils.DeserializeObject(br);
            Message = StringUtil.Deserialize(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ObjectUtils.SerializeObject(Peer, bw);
            ObjectUtils.SerializeObject(Id, bw);
            ObjectUtils.SerializeObject(Reason, bw);
            StringUtil.Serialize(Message, bw);

        }

        public override void DeserializeResponse(BinaryReader br)
        {
            Response = BoolUtil.Deserialize(br);

        }
    }
}
