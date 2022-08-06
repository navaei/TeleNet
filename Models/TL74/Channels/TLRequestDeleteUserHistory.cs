using System.IO;
using TeleNet.Models.TL.Messages;

namespace TeleNet.Models.TL.Channels
{
    [TLObject(-787622117)]
    public class TLRequestDeleteUserHistory : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return -787622117;
            }
        }

        public TLAbsInputChannel Channel { get; set; }
        public TLAbsInputUser UserId { get; set; }
        public TLAffectedHistory Response { get; set; }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Channel = (TLAbsInputChannel)ObjectUtils.DeserializeObject(br);
            UserId = (TLAbsInputUser)ObjectUtils.DeserializeObject(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ObjectUtils.SerializeObject(Channel, bw);
            ObjectUtils.SerializeObject(UserId, bw);

        }
        public override void DeserializeResponse(BinaryReader br)
        {
            Response = (TLAffectedHistory)ObjectUtils.DeserializeObject(br);

        }
    }
}
