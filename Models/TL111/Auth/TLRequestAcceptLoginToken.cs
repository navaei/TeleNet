using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL111.Auth
{
    [TLObject(-392909491)]
    public class TLRequestAcceptLoginToken : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return -392909491;
            }
        }

        public byte[] Token { get; set; }
        public TLAbsAuthorization Response { get; set; }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Token = BytesUtil.Deserialize(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            BytesUtil.Serialize(Token, bw);

        }

        public override void DeserializeResponse(BinaryReader br)
        {
            Response = (TLAbsAuthorization)ObjectUtils.DeserializeObject(br);

        }
    }
}
