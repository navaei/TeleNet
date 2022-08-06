using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL133.Messages
{
    [TLObject(745510839)]
    public class TLRequestGetMessageReadParticipants : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return 745510839;
            }
        }

        public TLAbsInputPeer Peer { get; set; }
        public int MsgId { get; set; }
        public TLVector<long> Response { get; set; }


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
            Response = (TLVector<long>)ObjectUtils.DeserializeVector<long>(br);

        }
    }
}
