using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL133.Messages
{
    [TLObject(428848198)]
    public class TLRequestRequestUrlAuth : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return 428848198;
            }
        }

        public int Flags { get; set; }
        public TLAbsInputPeer Peer { get; set; }
        public int? MsgId { get; set; }
        public int? ButtonId { get; set; }
        public string Url { get; set; }
        public TeleNet.Models.TL100.TLAbsUrlAuthResult Response { get; set; }


        public void ComputeFlags()
        {
            Flags = 0;
            Flags = Peer != null ? (Flags | 2) : (Flags & ~2);
            Flags = MsgId != null ? (Flags | 2) : (Flags & ~2);
            Flags = ButtonId != null ? (Flags | 2) : (Flags & ~2);
            Flags = Url != null ? (Flags | 4) : (Flags & ~4);

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
            if ((Flags & 2) != 0)
                Peer = (TLAbsInputPeer)ObjectUtils.DeserializeObject(br);
            else
                Peer = null;

            if ((Flags & 2) != 0)
                MsgId = br.ReadInt32();
            else
                MsgId = null;

            if ((Flags & 2) != 0)
                ButtonId = br.ReadInt32();
            else
                ButtonId = null;

            if ((Flags & 4) != 0)
                Url = StringUtil.Deserialize(br);
            else
                Url = null;


        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ComputeFlags();
            bw.Write(Flags);
            if ((Flags & 2) != 0)
                ObjectUtils.SerializeObject(Peer, bw);
            if ((Flags & 2) != 0)
                bw.Write(MsgId.Value);
            if ((Flags & 2) != 0)
                bw.Write(ButtonId.Value);
            if ((Flags & 4) != 0)
                StringUtil.Serialize(Url, bw);

        }

        public override void DeserializeResponse(BinaryReader br)
        {
            Response = (TeleNet.Models.TL100.TLAbsUrlAuthResult)ObjectUtils.DeserializeObject(br);

        }
    }
}
