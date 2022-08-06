using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL133
{
    [TLObject(1536380829)]
    public class TLInputChannelFromMessage : TLAbsInputChannel
    {
        public override int Constructor
        {
            get
            {
                return 1536380829;
            }
        }

        public TLAbsInputPeer Peer { get; set; }
        public int MsgId { get; set; }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Peer = (TLAbsInputPeer)ObjectUtils.DeserializeObject(br);
            MsgId = br.ReadInt32();
            ChannelId = br.ReadInt64();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ObjectUtils.SerializeObject(Peer, bw);
            bw.Write(MsgId);
            bw.Write(ChannelId);

        }
    }
}
