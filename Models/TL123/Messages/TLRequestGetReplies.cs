using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL123.Messages
{
    [TLObject(615875002)]
    public class TLRequestGetReplies : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return 615875002;
            }
        }

        public TLAbsInputPeer Peer { get; set; }
        public int MsgId { get; set; }
        public int OffsetId { get; set; }
        public int OffsetDate { get; set; }
        public int AddOffset { get; set; }
        public int Limit { get; set; }
        public int MaxId { get; set; }
        public int MinId { get; set; }
        public int Hash { get; set; }
        public TeleNet.Models.TL.Messages.TLAbsMessages Response { get; set; }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Peer = (TLAbsInputPeer)ObjectUtils.DeserializeObject(br);
            MsgId = br.ReadInt32();
            OffsetId = br.ReadInt32();
            OffsetDate = br.ReadInt32();
            AddOffset = br.ReadInt32();
            Limit = br.ReadInt32();
            MaxId = br.ReadInt32();
            MinId = br.ReadInt32();
            Hash = br.ReadInt32();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ObjectUtils.SerializeObject(Peer, bw);
            bw.Write(MsgId);
            bw.Write(OffsetId);
            bw.Write(OffsetDate);
            bw.Write(AddOffset);
            bw.Write(Limit);
            bw.Write(MaxId);
            bw.Write(MinId);
            bw.Write(Hash);

        }

        public override void DeserializeResponse(BinaryReader br)
        {
            Response = (TeleNet.Models.TL.Messages.TLAbsMessages)ObjectUtils.DeserializeObject(br);

        }
    }
}
