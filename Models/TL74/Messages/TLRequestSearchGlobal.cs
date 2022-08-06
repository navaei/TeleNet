using System.IO;
using TeleNet.Models.TL.Messages;

namespace TeleNet.Models.TL.Messages
{
    [TLObject(-1640190800)]
    public class TLRequestSearchGlobal : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return -1640190800;
            }
        }

        public string Q { get; set; }
        public int OffsetDate { get; set; }
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
            OffsetDate = br.ReadInt32();
            OffsetPeer = (TLAbsInputPeer)ObjectUtils.DeserializeObject(br);
            OffsetId = br.ReadInt32();
            Limit = br.ReadInt32();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            StringUtil.Serialize(Q, bw);
            bw.Write(OffsetDate);
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
