using System.IO;

namespace TeleNet.Models.TL
{
    [TLObject(386986326)]
    public class TLUpdateEncryptedChatTyping : TLAbsUpdate
    {
        public override int Constructor
        {
            get
            {
                return 386986326;
            }
        }

        public int ChatId { get; set; }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            ChatId = br.ReadInt32();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(ChatId);

        }
    }
}
