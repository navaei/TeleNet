using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL123
{
    [TLObject(-1495959709)]
    public class TLMessageReplyHeader : TLObject
    {
        public override int Constructor
        {
            get
            {
                return -1495959709;
            }
        }

        public int Flags { get; set; }
        public int ReplyToMsgId { get; set; }
        public TLAbsPeer ReplyToPeerId { get; set; }
        public int? ReplyToTopId { get; set; }


        public void ComputeFlags()
        {
            Flags = 0;
            Flags = ReplyToPeerId != null ? (Flags | 1) : (Flags & ~1);
            Flags = ReplyToTopId != null ? (Flags | 2) : (Flags & ~2);

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
            ReplyToMsgId = br.ReadInt32();
            if ((Flags & 1) != 0)
                ReplyToPeerId = (TLAbsPeer)ObjectUtils.DeserializeObject(br);
            else
                ReplyToPeerId = null;

            if ((Flags & 2) != 0)
                ReplyToTopId = br.ReadInt32();
            else
                ReplyToTopId = null;


        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ComputeFlags();
            bw.Write(Flags);
            bw.Write(ReplyToMsgId);
            if ((Flags & 1) != 0)
                ObjectUtils.SerializeObject(ReplyToPeerId, bw);
            if ((Flags & 2) != 0)
                bw.Write(ReplyToTopId.Value);

        }
    }
}
