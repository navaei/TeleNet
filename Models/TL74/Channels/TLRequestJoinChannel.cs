using System.IO;

namespace TeleNet.Models.TL.Channels
{
    [TLObject(615851205)]
    public class TLRequestJoinChannel : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return 615851205;
            }
        }

        public TLAbsInputChannel Channel { get; set; }
        public TLAbsUpdates Response { get; set; }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Channel = (TLAbsInputChannel)ObjectUtils.DeserializeObject(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ObjectUtils.SerializeObject(Channel, bw);

        }
        public override void DeserializeResponse(BinaryReader br)
        {
            Response = (TLAbsUpdates)ObjectUtils.DeserializeObject(br);

        }
    }
}
