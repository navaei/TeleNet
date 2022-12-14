using System.IO;
using TeleNet.Models.TL.Messages;

namespace TeleNet.Models.TL.Messages
{
    [TLObject(-1802240206)]
    public class TLSentEncryptedFile : TLAbsSentEncryptedMessage
    {
        public override int Constructor
        {
            get
            {
                return -1802240206;
            }
        }

        public int Date { get; set; }
        public TLAbsEncryptedFile File { get; set; }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Date = br.ReadInt32();
            File = (TLAbsEncryptedFile)ObjectUtils.DeserializeObject(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(Date);
            ObjectUtils.SerializeObject(File, bw);

        }
    }
}
