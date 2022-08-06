using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL133.Messages
{
    [TLObject(2127598753)]
    public class TLRequestGetOldFeaturedStickers : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return 2127598753;
            }
        }

        public int Offset { get; set; }
        public int Limit { get; set; }
        public long Hash { get; set; }
        public TeleNet.Models.TL.Messages.TLAbsFeaturedStickers Response { get; set; }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Offset = br.ReadInt32();
            Limit = br.ReadInt32();
            Hash = br.ReadInt64();

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
            Response = ( TeleNet.Models.TL.Messages.TLAbsFeaturedStickers)ObjectUtils.DeserializeObject(br);

        }
    }
}
