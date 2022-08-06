using System.IO;

namespace TeleNet.Models.TL.Messages
{
    [TLObject(2106086025)]
    public class TLRequestExportChatInvite : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return 2106086025;
            }
        }

        public int ChatId { get; set; }
        public TLAbsExportedChatInvite Response { get; set; }


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
        public override void DeserializeResponse(BinaryReader br)
        {
            Response = (TLAbsExportedChatInvite)ObjectUtils.DeserializeObject(br);

        }
    }
}
