using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL123.Messages
{
    [TLObject(1147761405)]
    public class TLRequestGetDiscussionMessage : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return 1147761405;
            }
        }

        public TLAbsInputPeer Peer { get; set; }
        public int MsgId { get; set; }
        public Messages.TLDiscussionMessage Response { get; set; }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Peer = (TLAbsInputPeer)ObjectUtils.DeserializeObject(br);
            MsgId = br.ReadInt32();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ObjectUtils.SerializeObject(Peer, bw);
            bw.Write(MsgId);

        }

        public override void DeserializeResponse(BinaryReader br)
        {
            Response = (Messages.TLDiscussionMessage)ObjectUtils.DeserializeObject(br);

        }
    }
}
