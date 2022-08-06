using System.IO;
using TeleNet.Models.TL;

namespace  TeleNet.Models.TL85.Channels
{
    [TLObject(-1383294429)]
    public class TLRequestGetMessages : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return -1383294429;
            }
        }

        public TLAbsInputChannel Channel { get; set; }
        public TLVector<TLAbsInputMessage> Id { get; set; }
        public TeleNet.Models.TL.Messages.TLAbsMessages Response { get; set; }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Channel = (TLAbsInputChannel)ObjectUtils.DeserializeObject(br);
            Id = (TLVector<TLAbsInputMessage>)ObjectUtils.DeserializeVector<TLAbsInputMessage>(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ObjectUtils.SerializeObject(Channel, bw);
            ObjectUtils.SerializeObject(Id, bw);

        }

        public override void DeserializeResponse(BinaryReader br)
        {
            Response = (TeleNet.Models.TL.Messages.TLAbsMessages)ObjectUtils.DeserializeObject(br);

        }
    }
}
