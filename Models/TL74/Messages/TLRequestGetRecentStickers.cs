using System.IO;
using TeleNet.Models.TL.Messages;

namespace TeleNet.Models.TL.Messages
{
    [TLObject(1587647177)]
    public class TLRequestGetRecentStickers : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return 1587647177;
            }
        }

        public int Flags { get; set; }
        public bool Attached { get; set; }
        public int Hash { get; set; }
        public TLAbsRecentStickers Response { get; set; }


        public void ComputeFlags()
        {
            Flags = 0;
            Flags = Attached ? (Flags | 1) : (Flags & ~1);

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
            Attached = (Flags & 1) != 0;
            Hash = br.ReadInt32();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ComputeFlags();
            bw.Write(Flags);

            bw.Write(Hash);

        }
        public override void DeserializeResponse(BinaryReader br)
        {
            Response = (TLAbsRecentStickers)ObjectUtils.DeserializeObject(br);

        }
    }
}
