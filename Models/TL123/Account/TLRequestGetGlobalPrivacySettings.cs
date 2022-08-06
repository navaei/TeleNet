using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL123.Account
{
    [TLObject(-349483786)]
    public class TLRequestGetGlobalPrivacySettings : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return -349483786;
            }
        }

        public TLGlobalPrivacySettings Response { get; set; }


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

        public override void DeserializeResponse(BinaryReader br)
        {
            Response = (TLGlobalPrivacySettings)ObjectUtils.DeserializeObject(br);

        }
    }
}
