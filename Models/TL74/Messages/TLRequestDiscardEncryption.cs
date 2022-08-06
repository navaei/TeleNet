using System.IO;

namespace TeleNet.Models.TL.Messages
{
    [TLObject(-304536635)]
    public class TLRequestDiscardEncryption : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return -304536635;
            }
        }

        public int ChatId { get; set; }
        public bool Response { get; set; }


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
            Response = BoolUtil.Deserialize(br);

        }
    }
}
