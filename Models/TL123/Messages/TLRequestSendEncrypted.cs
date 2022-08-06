using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL123.Messages
{
    [TLObject(1157265941)]
    public class TLRequestSendEncrypted : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return 1157265941;
            }
        }

        public int Flags { get; set; }
        public bool Silent { get; set; }
        public TLInputEncryptedChat Peer { get; set; }
        public long RandomId { get; set; }
        public byte[] Data { get; set; }
        public TL.Messages.TLAbsSentEncryptedMessage Response { get; set; }

        public void ComputeFlags()
        {
            Flags = 0;
            Flags = Silent ? (Flags | 1) : (Flags & ~1);

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
            Silent = (Flags & 1) != 0;
            Peer = (TLInputEncryptedChat)ObjectUtils.DeserializeObject(br);
            RandomId = br.ReadInt64();
            Data = BytesUtil.Deserialize(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ComputeFlags();
            bw.Write(Flags);

            ObjectUtils.SerializeObject(Peer, bw);
            bw.Write(RandomId);
            BytesUtil.Serialize(Data, bw);

        }

        public override void DeserializeResponse(BinaryReader br)
        {
            Response = (TeleNet.Models.TL.Messages.TLAbsSentEncryptedMessage)ObjectUtils.DeserializeObject(br);

        }
    }
}
