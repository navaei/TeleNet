using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL133.Account
{
    [TLObject(-977650298)]
    public class TLRequestReportPeer : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return -977650298;
            }
        }

        public TLAbsInputPeer Peer { get; set; }
        public TLAbsReportReason Reason { get; set; }
        public string Message { get; set; }
        public bool Response { get; set; }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Peer = (TLAbsInputPeer)ObjectUtils.DeserializeObject(br);
            Reason = (TLAbsReportReason)ObjectUtils.DeserializeObject(br);
            Message = StringUtil.Deserialize(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ObjectUtils.SerializeObject(Peer, bw);
            ObjectUtils.SerializeObject(Reason, bw);
            StringUtil.Serialize(Message, bw);

        }

        public override void DeserializeResponse(BinaryReader br)
        {
            Response = BoolUtil.Deserialize(br);

        }
    }
}
