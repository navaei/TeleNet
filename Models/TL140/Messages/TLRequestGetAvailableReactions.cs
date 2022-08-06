using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL140.Messages
{
    [TLObject(417243308)]
    public class TLRequestGetAvailableReactions : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return 417243308;
            }
        }

        public int Hash { get; set; }
        public Messages.TLAbsAvailableReactions Response { get; set; }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Hash = br.ReadInt32();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(Hash);

        }

        public override void DeserializeResponse(BinaryReader br)
        {
            Response = (Messages.TLAbsAvailableReactions)ObjectUtils.DeserializeObject(br);

        }
    }
}
