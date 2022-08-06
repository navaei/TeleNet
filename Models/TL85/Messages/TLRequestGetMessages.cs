using System.IO;
using TeleNet.Models.TL;

namespace  TeleNet.Models.TL85.Messages
{
    [TLObject(1673946374)]
    public class TLRequestGetMessages : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return 1673946374;
            }
        }

        public TLVector<TLAbsInputMessage> Id { get; set; }
        public TeleNet.Models.TL.Messages.TLAbsMessages Response { get; set; }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Id = (TLVector<TLAbsInputMessage>)ObjectUtils.DeserializeVector<TLAbsInputMessage>(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ObjectUtils.SerializeObject(Id, bw);

        }

        public override void DeserializeResponse(BinaryReader br)
        {
            Response = (TeleNet.Models.TL.Messages.TLAbsMessages)ObjectUtils.DeserializeObject(br);

        }
    }
}
