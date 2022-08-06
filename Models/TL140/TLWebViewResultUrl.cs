using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL140
{
    [TLObject(202659196)]
    public class TLWebViewResultUrl : TLAbsSimpleWebViewResult
    {
        public override int Constructor
        {
            get
            {
                return 202659196;
            }
        }

        public long QueryId { get; set; }
        public string Url { get; set; }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            QueryId = br.ReadInt64();
            Url = StringUtil.Deserialize(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(QueryId);
            StringUtil.Serialize(Url, bw);

        }
    }
}
