using System.IO;
using TeleNet.Models.TL.Contacts;

namespace TeleNet.Models.TL.Contacts
{
    [TLObject(-1219778094)]
    public class TLContactsNotModified : TLAbsContacts
    {
        public override int Constructor
        {
            get
            {
                return -1219778094;
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
