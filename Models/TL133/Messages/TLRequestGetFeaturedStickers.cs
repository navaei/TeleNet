using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL133.Messages
{
    [TLObject(1685588756)]
    public class TLRequestGetFeaturedStickers : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return 1685588756;
            }
        }

        public long Hash { get; set; }
        public TeleNet.Models.TL.Messages.TLAbsFeaturedStickers Response { get; set; }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Hash = br.ReadInt64();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(Hash);

        }

        public override void DeserializeResponse(BinaryReader br)
        {
            Response = ( TeleNet.Models.TL.Messages.TLAbsFeaturedStickers)ObjectUtils.DeserializeObject(br);

        }
    }
}
