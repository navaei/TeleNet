using System.IO;

namespace TeleNet.Models.TL.Channels
{
    [TLObject(1231065863)]
    public class TLRequestToggleInvites : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return 1231065863;
            }
        }

        public TLAbsInputChannel Channel { get; set; }
        public bool Enabled { get; set; }
        public TLAbsUpdates Response { get; set; }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Channel = (TLAbsInputChannel)ObjectUtils.DeserializeObject(br);
            Enabled = BoolUtil.Deserialize(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ObjectUtils.SerializeObject(Channel, bw);
            BoolUtil.Serialize(Enabled, bw);

        }
        public override void DeserializeResponse(BinaryReader br)
        {
            Response = (TLAbsUpdates)ObjectUtils.DeserializeObject(br);

        }
    }
}
