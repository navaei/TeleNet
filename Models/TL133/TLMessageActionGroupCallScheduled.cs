using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL133
{
    [TLObject(-1281329567)]
    public class TLMessageActionGroupCallScheduled : TLAbsMessageAction
    {
        public override int Constructor
        {
            get
            {
                return -1281329567;
            }
        }

        public TL123.TLInputGroupCall Call { get; set; }
        public int ScheduleDate { get; set; }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Call = (TL123.TLInputGroupCall)ObjectUtils.DeserializeObject(br);
            ScheduleDate = br.ReadInt32();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ObjectUtils.SerializeObject(Call, bw);
            bw.Write(ScheduleDate);

        }
    }
}
