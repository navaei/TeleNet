using System.IO;

namespace TeleNet.Models.TL
{
    [TLObject(218751099)]
    public class TLInputPrivacyValueAllowContacts : TLAbsInputPrivacyRule
    {
        public override int Constructor
        {
            get
            {
                return 218751099;
            }
        }



        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);

        }
    }
}
