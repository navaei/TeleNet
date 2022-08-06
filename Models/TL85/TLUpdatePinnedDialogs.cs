using System.IO;
using TeleNet.Models.TL;

namespace  TeleNet.Models.TL85
{
    [TLObject(-364071333)]
    public class TLUpdatePinnedDialogs : TLAbsUpdate
    {
        public override int Constructor
        {
            get
            {
                return -364071333;
            }
        }

        public int Flags { get; set; }
        public TLVector<TLDialogPeer> Order { get; set; }


        public void ComputeFlags()
        {
            Flags = 0;
            Flags = Order != null ? (Flags | 1) : (Flags & ~1);

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
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
            if ((Flags & 1) != 0)
                ObjectUtils.SerializeObject(Order, bw);

        }
    }
}
