using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL140.Contacts
{
    [TLObject(-1963375804)]
    public class TLRequestResolvePhone : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return -1963375804;
            }
        }

        public string Phone { get; set; }
        public Models.TL.Contacts.TLResolvedPeer Response { get; set; }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Phone = StringUtil.Deserialize(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            StringUtil.Serialize(Phone, bw);

        }

        public override void DeserializeResponse(BinaryReader br)
        {
            Response = (TL.Contacts.TLResolvedPeer)ObjectUtils.DeserializeObject(br);

        }
    }
}
