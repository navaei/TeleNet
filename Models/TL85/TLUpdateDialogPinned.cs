using System.IO;
using TeleNet.Models.TL;

namespace  TeleNet.Models.TL85
{
    [TLObject(433225532)]
    public class TLUpdateDialogPinned : TLAbsUpdate
    {
        public override int Constructor
        {
            get
            {
                return 433225532;
            }
        }

        public int Flags { get; set; }
        public bool Pinned { get; set; }
        public TLDialogPeer Peer { get; set; }


        public void ComputeFlags()
        {
            Flags = 0;
            Flags = Pinned ? (Flags | 1) : (Flags & ~1);

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
            Pinned = (Flags & 1) != 0;
            Peer = (TLDialogPeer)ObjectUtils.DeserializeObject(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ComputeFlags();
            bw.Write(Flags);

            ObjectUtils.SerializeObject(Peer, bw);

        }
    }
}
