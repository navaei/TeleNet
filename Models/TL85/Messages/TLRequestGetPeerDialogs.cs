using System.IO;

namespace TeleNet.Models.TL85.Messages
{
    [TLObject(-462373635)]
    public class TLRequestGetPeerDialogs : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return -462373635;
            }
        }

        public TLVector<TLInputDialogPeer> Peers { get; set; }
        public TeleNet.Models.TL.Messages.TLPeerDialogs Response { get; set; }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Peers = (TLVector<TLInputDialogPeer>)ObjectUtils.DeserializeVector<TLInputDialogPeer>(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ObjectUtils.SerializeObject(Peers, bw);

        }

        public override void DeserializeResponse(BinaryReader br)
        {
            Response = (TeleNet.Models.TL.Messages.TLPeerDialogs)ObjectUtils.DeserializeObject(br);

        }
    }
}
