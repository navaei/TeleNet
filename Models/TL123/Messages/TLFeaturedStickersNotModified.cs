using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;
using TeleNet.Models.TL.Messages;

namespace TeleNet.Models.TL123.Messages
{
    [TLObject(-958657434)]
    public class TLFeaturedStickersNotModified : TLAbsFeaturedStickers
    {
        public override int Constructor
        {
            get
            {
                return -958657434;
            }
        }

        public int Count { get; set; }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Count = br.ReadInt32();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(Count);

        }
    }
}
