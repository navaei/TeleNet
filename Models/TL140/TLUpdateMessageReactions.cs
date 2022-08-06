using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL140
{
    [TLObject(357013699)]
    public class TLUpdateMessageReactions : TLAbsUpdate
    {
        public override int Constructor
        {
            get
            {
                return 357013699;
            }
        }

        public TLAbsPeer Peer { get; set; }
        public int MsgId { get; set; }
        public TLMessageReactions Reactions { get; set; }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Peer = (TLAbsPeer)ObjectUtils.DeserializeObject(br);
            MsgId = br.ReadInt32();
            Reactions = (TLMessageReactions)ObjectUtils.DeserializeObject(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ObjectUtils.SerializeObject(Peer, bw);
            bw.Write(MsgId);
            ObjectUtils.SerializeObject(Reactions, bw);

        }
    }
}
