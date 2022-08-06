using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL140.Messages
{
    [TLObject(-2099097129)]
    public class TLRequestReadReactions : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return -2099097129;
            }
        }

        public TLAbsInputPeer Peer { get; set; }
        public TL.Messages.TLAffectedHistory Response { get; set; }


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
            Response = (TL.Messages.TLAffectedHistory)ObjectUtils.DeserializeObject(br);
        }
    }
}
