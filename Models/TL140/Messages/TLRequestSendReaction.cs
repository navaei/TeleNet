using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL140.Messages
{
    [TLObject(627641572)]
    public class TLRequestSendReaction : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return 627641572;
            }
        }

        public int Flags { get; set; }
        public bool Big { get; set; }
        public TLAbsInputPeer Peer { get; set; }
        public int MsgId { get; set; }
        public string Reaction { get; set; }
        public TLAbsUpdates Response { get; set; }


        public void ComputeFlags()
        {
            Flags = 0;
            Flags = Big ? (Flags | 2) : (Flags & ~2);
            Flags = Reaction != null ? (Flags | 1) : (Flags & ~1);

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
            Big = (Flags & 2) != 0;
            Peer = (TLAbsInputPeer)ObjectUtils.DeserializeObject(br);
            MsgId = br.ReadInt32();
            if ((Flags & 1) != 0)
                Reaction = StringUtil.Deserialize(br);
            else
                Reaction = null;


        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ComputeFlags();
            bw.Write(Flags);

            ObjectUtils.SerializeObject(Peer, bw);
            bw.Write(MsgId);
            if ((Flags & 1) != 0)
                StringUtil.Serialize(Reaction, bw);

        }

        public override void DeserializeResponse(BinaryReader br)
        {
            Response = (TLAbsUpdates)ObjectUtils.DeserializeObject(br);

        }
    }
}
