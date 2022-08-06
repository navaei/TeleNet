using System.IO;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL140.Messages
{
    [TLObject(276705696)]
    public class TLRequestSearchSentMedia : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return 276705696;
            }
        }

        public string Q { get; set; }
        public TLAbsMessagesFilter Filter { get; set; }
        public int Limit { get; set; }
        public Models.TL.Messages.TLAbsMessages Response { get; set; }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Q = StringUtil.Deserialize(br);
            Filter = (TLAbsMessagesFilter)ObjectUtils.DeserializeObject(br);
            Limit = br.ReadInt32();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            StringUtil.Serialize(Q, bw);
            ObjectUtils.SerializeObject(Filter, bw);
            bw.Write(Limit);

        }

        public override void DeserializeResponse(BinaryReader br)
        {
            Response = (Models.TL.Messages.TLAbsMessages)ObjectUtils.DeserializeObject(br);

        }
    }
}
