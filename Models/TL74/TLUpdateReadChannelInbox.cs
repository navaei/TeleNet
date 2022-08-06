using System.IO;

namespace TeleNet.Models.TL
{
    [TLObject(1108669311)]
    public class TLUpdateReadChannelInbox : TLAbsUpdate
    {
        public override int Constructor
        {
            get
            {
                return 1108669311;
            }
        }

        public int ChannelId { get; set; }
        public int MaxId { get; set; }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            ChannelId = br.ReadInt32();
            MaxId = br.ReadInt32();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(ChannelId);
            bw.Write(MaxId);

        }
    }
}
