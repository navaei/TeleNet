using System.IO;

namespace TeleNet.Models.TL
{
    [TLObject(-1425052898)]
    public class TLUpdatePhoneCall : TLAbsUpdate
    {
        public override int Constructor
        {
            get
            {
                return -1425052898;
            }
        }

        public TLAbsPhoneCall PhoneCall { get; set; }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            PhoneCall = (TLAbsPhoneCall)ObjectUtils.DeserializeObject(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ObjectUtils.SerializeObject(PhoneCall, bw);

        }
    }
}
