using System.IO;
using TeleNet.Models.TL;

namespace  TeleNet.Models.TL85.Messages
{
    [TLObject(-1332171034)]
    public class TLRequestGetDialogs : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return -1332171034;
            }
        }

        public int Flags { get; set; }
        public bool ExcludePinned { get; set; }
        public int OffsetDate { get; set; }
        public int OffsetId { get; set; }
        public TLAbsInputPeer OffsetPeer { get; set; }
        public int Limit { get; set; }
        public int Hash { get; set; }
        public TeleNet.Models.TL.Messages.TLAbsDialogs Response { get; set; }


        public void ComputeFlags()
        {
            Flags = 0;
            Flags = ExcludePinned ? (Flags | 1) : (Flags & ~1);

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
            ExcludePinned = (Flags & 1) != 0;
            OffsetDate = br.ReadInt32();
            OffsetId = br.ReadInt32();
            OffsetPeer = (TLAbsInputPeer)ObjectUtils.DeserializeObject(br);
            Limit = br.ReadInt32();
            Hash = br.ReadInt32();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ComputeFlags();
            bw.Write(Flags);

            bw.Write(OffsetDate);
            bw.Write(OffsetId);
            ObjectUtils.SerializeObject(OffsetPeer, bw);
            bw.Write(Limit);
            bw.Write(Hash);

        }

        public override void DeserializeResponse(BinaryReader br)
        {
            Response = (TeleNet.Models.TL.Messages.TLAbsDialogs)ObjectUtils.DeserializeObject(br);

        }
    }
}
