using System.IO;

namespace TeleNet.Models.TL.Channels
{
    [TLObject(-130635115)]
    public class TLRequestLeaveChannel : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return -130635115;
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
