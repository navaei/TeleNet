using System.IO;

namespace TeleNet.Models.TL
{
    [TLObject(320652927)]
    public class TLInputPrivacyValueAllowUsers : TLAbsInputPrivacyRule
    {
        public override int Constructor
        {
            get
            {
                return 320652927;
            }
        }

        public TLVector<TLAbsInputUser> Users { get; set; }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Users = (TLVector<TLAbsInputUser>)ObjectUtils.DeserializeVector<TLAbsInputUser>(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ObjectUtils.SerializeObject(Users, bw);

        }
    }
}
