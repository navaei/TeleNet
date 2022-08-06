using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL123.Stats
{
    [TLObject(1445996571)]
    public class TLRequestGetMessagePublicForwards : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return 1445996571;
            }
        }

        public TLAbsInputChannel Channel { get; set; }
        public int MsgId { get; set; }
        public int OffsetRate { get; set; }
        public TLAbsInputPeer OffsetPeer { get; set; }
        public int OffsetId { get; set; }
        public int Limit { get; set; }
        public TeleNet.Models.TL.Messages.TLAbsMessages Response { get; set; }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Channel = (TLAbsInputChannel)ObjectUtils.DeserializeObject(br);
            MsgId = br.ReadInt32();
            OffsetRate = br.ReadInt32();
            OffsetPeer = (TLAbsInputPeer)ObjectUtils.DeserializeObject(br);
            OffsetId = br.ReadInt32();
            Limit = br.ReadInt32();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ObjectUtils.SerializeObject(Channel, bw);
            bw.Write(MsgId);
            bw.Write(OffsetRate);
            ObjectUtils.SerializeObject(OffsetPeer, bw);
            bw.Write(OffsetId);
            bw.Write(Limit);

        }

        public override void DeserializeResponse(BinaryReader br)
        {
            Response = (TeleNet.Models.TL.Messages.TLAbsMessages)ObjectUtils.DeserializeObject(br);

        }
    }
}
