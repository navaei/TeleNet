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
    [TLObject(-99664734)]
    public class TLUpdatePinnedDialogs : TLAbsUpdate
    {
        public override int Constructor
        {
            get
            {
                return -99664734;
            }
        }

        public int Flags { get; set; }
        public int? FolderId { get; set; }
        public TLVector<TLDialogPeer> Order { get; set; }


        public void ComputeFlags()
        {
            Flags = 0;
            Flags = FolderId != null ? (Flags | 2) : (Flags & ~2);
            Flags = Order != null ? (Flags | 1) : (Flags & ~1);

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
            if ((Flags & 2) != 0)
                FolderId = br.ReadInt32();
            else
                FolderId = null;

            if ((Flags & 1) != 0)
                Order = (TLVector<TLDialogPeer>)ObjectUtils.DeserializeVector<TLDialogPeer>(br);
            else
                Order = null;


        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ComputeFlags();
            bw.Write(Flags);
            if ((Flags & 2) != 0)
                bw.Write(FolderId.Value);
            if ((Flags & 1) != 0)
                ObjectUtils.SerializeObject(Order, bw);

        }
    }
}
