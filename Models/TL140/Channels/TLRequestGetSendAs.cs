using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL140.Channels
{
    [TLObject(231174382)]
    public class TLRequestGetSendAs : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return 231174382;
            }
        }

        public TLAbsInputPeer Peer { get; set; }
        public Channels.TLSendAsPeers Response { get; set; }


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
            Response = (Channels.TLSendAsPeers)ObjectUtils.DeserializeObject(br);

        }
    }
}
