using System.IO;

namespace TeleNet.Models.TL
{
    [TLObject(-1613493288)]
    public class TLNotifyPeer : TLAbsNotifyPeer
    {
        public override int Constructor
        {
            get
            {
                return -1613493288;
            }
        }

        public TLAbsPeer Peer { get; set; }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Peer = (TLAbsPeer)ObjectUtils.DeserializeObject(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ObjectUtils.SerializeObject(Peer, bw);

        }
    }
}
