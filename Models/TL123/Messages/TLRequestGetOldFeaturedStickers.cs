using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL123.Messages
{
    [TLObject(1608974939)]
    public class TLRequestGetOldFeaturedStickers : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return 1608974939;
            }
        }

        public int Offset { get; set; }
        public int Limit { get; set; }
        public int Hash { get; set; }
        public TeleNet.Models.TL.Messages.TLAbsFeaturedStickers Response { get; set; }

        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Offset = br.ReadInt32();
            Limit = br.ReadInt32();
            Hash = br.ReadInt32();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(Offset);
            bw.Write(Limit);
            bw.Write(Hash);

        }

        public override void DeserializeResponse(BinaryReader br)
        {
            Response = (TeleNet.Models.TL.Messages.TLAbsFeaturedStickers)ObjectUtils.DeserializeObject(br);

        }
    }
}
