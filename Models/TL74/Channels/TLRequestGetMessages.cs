using System.IO;
using TeleNet.Models.TL.Messages;

namespace TeleNet.Models.TL.Channels
{
    [TLObject(-1814580409)]
    public class TLRequestGetMessages : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return -1814580409;
            }
        }

        public TLAbsInputChannel Channel { get; set; }
        public TLVector<int> Id { get; set; }
        public TLAbsMessages Response { get; set; }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Channel = (TLAbsInputChannel)ObjectUtils.DeserializeObject(br);
            Id = (TLVector<int>)ObjectUtils.DeserializeVector<int>(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ObjectUtils.SerializeObject(Channel, bw);
            ObjectUtils.SerializeObject(Id, bw);

        }
        public override void DeserializeResponse(BinaryReader br)
        {
            Response = (TLAbsMessages)ObjectUtils.DeserializeObject(br);

        }
    }
}
