using System.IO;

namespace TeleNet.Models.TL
{
    [TLObject(548253432)]
    public class TLInputPeerChannel : TLAbsInputPeer
    {
        public override int Constructor
        {
            get
            {
                return 548253432;
            }
        }

        public int ChannelId { get; set; }
        public long AccessHash { get; set; }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            ChannelId = br.ReadInt32();
            AccessHash = br.ReadInt64();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(ChannelId);
            bw.Write(AccessHash);

        }
    }
}
