using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL140.Messages
{
    [TLObject(1404185519)]
    public class TLSearchResultsPositions : TLObject
    {
        public override int Constructor
        {
            get
            {
                return 1404185519;
            }
        }

        public int Count { get; set; }
        public TLVector<TLSearchResultPosition> Positions { get; set; }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Count = br.ReadInt32();
            Positions = ObjectUtils.DeserializeVector<TLSearchResultPosition>(br);
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(Count);
            ObjectUtils.SerializeObject(Positions, bw);

        }
    }
}
