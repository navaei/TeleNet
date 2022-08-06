using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;
using TeleNet.Models.TL111;

namespace TeleNet.Models.TL123.Stats
{
    [TLObject(-1986399595)]
    public class TLMessageStats : TLObject
    {
        public override int Constructor
        {
            get
            {
                return -1986399595;
            }
        }

        public TLAbsStatsGraph ViewsGraph { get; set; }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            ViewsGraph = (TLAbsStatsGraph)ObjectUtils.DeserializeObject(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ObjectUtils.SerializeObject(ViewsGraph, bw);

        }
    }
}
