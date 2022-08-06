using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL133.Auth
{
    [TLObject(-1210022402)]
    public class TLRequestExportLoginToken : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return -1210022402;
            }
        }

        public int ApiId { get; set; }
        public string ApiHash { get; set; }
        public TLVector<long> ExceptIds { get; set; }
        public TeleNet.Models.TL111.Auth.TLAbsLoginToken Response { get; set; }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            ApiId = br.ReadInt32();
            ApiHash = StringUtil.Deserialize(br);
            ExceptIds = (TLVector<long>)ObjectUtils.DeserializeVector<long>(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(ApiId);
            StringUtil.Serialize(ApiHash, bw);
            ObjectUtils.SerializeObject(ExceptIds, bw);

        }

        public override void DeserializeResponse(BinaryReader br)
        {
            Response = (TeleNet.Models.TL111.Auth.TLAbsLoginToken)ObjectUtils.DeserializeObject(br);

        }
    }
}
