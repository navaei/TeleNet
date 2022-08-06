using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;
using  TeleNet.Models.TL.Auth;

namespace  TeleNet.Models.TL96.Auth
{
    [TLObject(-1502141361)]
    public class TLRequestSendCode : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return -1502141361;
            }
        }

        public string PhoneNumber { get; set; }
        public int ApiId { get; set; }
        public string ApiHash { get; set; }
        public TLAbsCodeSettings Settings { get; set; }
        public TLSentCode Response { get; set; }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            PhoneNumber = StringUtil.Deserialize(br);
            ApiId = br.ReadInt32();
            ApiHash = StringUtil.Deserialize(br);
            Settings = (TLAbsCodeSettings)ObjectUtils.DeserializeObject(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            StringUtil.Serialize(PhoneNumber, bw);
            bw.Write(ApiId);
            StringUtil.Serialize(ApiHash, bw);
            ObjectUtils.SerializeObject(Settings, bw);

        }

        public override void DeserializeResponse(BinaryReader br)
        {
            Response = (TLSentCode)ObjectUtils.DeserializeObject(br);

        }
    }
}
