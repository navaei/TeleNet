using System.IO;

namespace TeleNet.Models.TL
{
    [TLObject(-247351839)]
    public class TLInputEncryptedChat : TLObject
    {
        public override int Constructor
        {
            get
            {
                return -247351839;
            }
        }

        public int ChatId { get; set; }
        public long AccessHash { get; set; }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            ChatId = br.ReadInt32();
            AccessHash = br.ReadInt64();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(ChatId);
            bw.Write(AccessHash);

        }
    }
}
