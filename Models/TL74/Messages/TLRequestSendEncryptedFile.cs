using System.IO;
using TeleNet.Models.TL.Messages;

namespace TeleNet.Models.TL.Messages
{
    [TLObject(-1701831834)]
    public class TLRequestSendEncryptedFile : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return -1701831834;
            }
        }

        public TLInputEncryptedChat Peer { get; set; }
        public long RandomId { get; set; }
        public byte[] Data { get; set; }
        public TLAbsInputEncryptedFile File { get; set; }
        public TLAbsSentEncryptedMessage Response { get; set; }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Peer = (TLInputEncryptedChat)ObjectUtils.DeserializeObject(br);
            RandomId = br.ReadInt64();
            Data = BytesUtil.Deserialize(br);
            File = (TLAbsInputEncryptedFile)ObjectUtils.DeserializeObject(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ObjectUtils.SerializeObject(Peer, bw);
            bw.Write(RandomId);
            BytesUtil.Serialize(Data, bw);
            ObjectUtils.SerializeObject(File, bw);

        }
        public override void DeserializeResponse(BinaryReader br)
        {
            Response = (TLAbsSentEncryptedMessage)ObjectUtils.DeserializeObject(br);

        }
    }
}
