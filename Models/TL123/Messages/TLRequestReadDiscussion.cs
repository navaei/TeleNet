using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL123.Messages
{
    [TLObject(-147740172)]
    public class TLRequestReadDiscussion : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return -147740172;
            }
        }

        public TLAbsInputPeer Peer { get; set; }
        public int MsgId { get; set; }
        public int ReadMaxId { get; set; }
        public bool Response { get; set; }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Peer = (TLAbsInputPeer)ObjectUtils.DeserializeObject(br);
            MsgId = br.ReadInt32();
            ReadMaxId = br.ReadInt32();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ObjectUtils.SerializeObject(Peer, bw);
            bw.Write(MsgId);
            bw.Write(ReadMaxId);

        }

        public override void DeserializeResponse(BinaryReader br)
        {
            Response = BoolUtil.Deserialize(br);

        }
    }
}
