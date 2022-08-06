using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;
using  TeleNet.Models.TL.Auth;

namespace  TeleNet.Models.TL96.Account
{
    [TLObject(457157256)]
    public class TLRequestSendConfirmPhoneCode : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return 457157256;
            }
        }

        public string Hash { get; set; }
        public TLCodeSettings Settings { get; set; }
        public TLSentCode Response { get; set; }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Hash = StringUtil.Deserialize(br);
            Settings = (TLCodeSettings)ObjectUtils.DeserializeObject(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            StringUtil.Serialize(Hash, bw);
            ObjectUtils.SerializeObject(Settings, bw);

        }

        public override void DeserializeResponse(BinaryReader br)
        {
            Response = (TLSentCode)ObjectUtils.DeserializeObject(br);

        }
    }
}
