using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL123.Messages
{
    [TLObject(-2094760687)]
    public class TLRequestDeleteChat : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return -2094760687;
            }
        }

        public int ChatId { get; set; }
        public bool Response { get; set; }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            ChatId = br.ReadInt32();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(ChatId);

        }

        public override void DeserializeResponse(BinaryReader br)
        {
            Response = BoolUtil.Deserialize(br);

        }
    }
}
