using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL140.Messages
{
    [TLObject(-396644838)]
    public class TLRequestGetUnreadReactions : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return -396644838;
            }
        }

        public TLAbsInputPeer Peer { get; set; }
        public int OffsetId { get; set; }
        public int AddOffset { get; set; }
        public int Limit { get; set; }
        public int MaxId { get; set; }
        public int MinId { get; set; }
        public TL.Messages.TLAbsMessages Response { get; set; }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Peer = (TLAbsInputPeer)ObjectUtils.DeserializeObject(br);
            OffsetId = br.ReadInt32();
            AddOffset = br.ReadInt32();
            Limit = br.ReadInt32();
            MaxId = br.ReadInt32();
            MinId = br.ReadInt32();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ObjectUtils.SerializeObject(Peer, bw);
            bw.Write(OffsetId);
            bw.Write(AddOffset);
            bw.Write(Limit);
            bw.Write(MaxId);
            bw.Write(MinId);

        }

        public override void DeserializeResponse(BinaryReader br)
        {
            Response = (TL.Messages.TLAbsMessages)ObjectUtils.DeserializeObject(br);

        }
    }
}
