using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;
using TeleNet.Models.TL.Messages;

namespace  TeleNet.Models.TL100.Messages
{
    [TLObject(259638801)]
    public class TLRequestSearchGlobal : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return 259638801;
            }
        }

        public string Q { get; set; }
        public int OffsetRate { get; set; }
        public TLAbsInputPeer OffsetPeer { get; set; }
        public int OffsetId { get; set; }
        public int Limit { get; set; }
        public TLAbsMessages Response { get; set; }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Q = StringUtil.Deserialize(br);
            OffsetRate = br.ReadInt32();
            OffsetPeer = (TLAbsInputPeer)ObjectUtils.DeserializeObject(br);
            OffsetId = br.ReadInt32();
            Limit = br.ReadInt32();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            StringUtil.Serialize(Q, bw);
            bw.Write(OffsetRate);
            ObjectUtils.SerializeObject(OffsetPeer, bw);
            bw.Write(OffsetId);
            bw.Write(Limit);

        }

        public override void DeserializeResponse(BinaryReader br)
        {
            Response = (TLAbsMessages)ObjectUtils.DeserializeObject(br);

        }
    }
}
