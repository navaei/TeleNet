using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL99
{
    [TLObject(1852826908)]
    public class TLUpdateDialogPinned : TLAbsUpdate
    {
        public override int Constructor
        {
            get
            {
                return 1852826908;
            }
        }

        public int Flags { get; set; }
        public bool Pinned { get; set; }
        public int? FolderId { get; set; }
        public TLDialogPeer Peer { get; set; }


        public void ComputeFlags()
        {
            Flags = 0;
            Flags = Pinned ? (Flags | 1) : (Flags & ~1);
            Flags = FolderId != null ? (Flags | 2) : (Flags & ~2);

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
            Pinned = (Flags & 1) != 0;
            if ((Flags & 2) != 0)
                FolderId = br.ReadInt32();
            else
                FolderId = null;

            Peer = (TLDialogPeer)ObjectUtils.DeserializeObject(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ComputeFlags();
            bw.Write(Flags);

            if ((Flags & 2) != 0)
                bw.Write(FolderId.Value);
            ObjectUtils.SerializeObject(Peer, bw);

        }
    }
}
