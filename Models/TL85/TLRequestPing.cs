using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;
using TeleNet.Models.TL74;

namespace TeleNet.Models.TL85
{
    [TLObject(2059302892)]
    public class TLRequestPing : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return 2059302892;
            }
        }

        public long PingId { get; set; }
        public TL.TLPong Response { get; set; }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            PingId = br.ReadInt64();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(PingId);

        }

        public override void DeserializeResponse(BinaryReader br)
        {
            Response = (TL.TLPong)ObjectUtils.DeserializeObject(br);

        }
    }
}
