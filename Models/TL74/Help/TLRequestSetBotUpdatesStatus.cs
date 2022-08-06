using System.IO;

namespace TeleNet.Models.TL.Help
{
    [TLObject(-333262899)]
    public class TLRequestSetBotUpdatesStatus : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return -333262899;
            }
        }

        public int PendingUpdatesCount { get; set; }
        public string Message { get; set; }
        public bool Response { get; set; }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            PendingUpdatesCount = br.ReadInt32();
            Message = StringUtil.Deserialize(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(PendingUpdatesCount);
            StringUtil.Serialize(Message, bw);

        }
        public override void DeserializeResponse(BinaryReader br)
        {
            Response = BoolUtil.Deserialize(br);

        }
    }
}
