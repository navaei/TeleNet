using System.IO;

namespace TeleNet.Models.TL
{
    [TLObject(956179895)]
    public class TLUpdateEncryptedMessagesRead : TLAbsUpdate
    {
        public override int Constructor
        {
            get
            {
                return 956179895;
            }
        }

        public int ChatId { get; set; }
        public int MaxDate { get; set; }
        public int Date { get; set; }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            ChatId = br.ReadInt32();
            MaxDate = br.ReadInt32();
            Date = br.ReadInt32();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(ChatId);
            bw.Write(MaxDate);
            bw.Write(Date);

        }
    }
}
