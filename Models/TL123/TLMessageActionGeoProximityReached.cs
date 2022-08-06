using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL123
{
    [TLObject(-1730095465)]
    public class TLMessageActionGeoProximityReached : TLAbsMessageAction
    {
        public override int Constructor
        {
            get
            {
                return -1730095465;
            }
        }

        public TLAbsPeer FromId { get; set; }
        public TLAbsPeer ToId { get; set; }
        public int Distance { get; set; }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            FromId = (TLAbsPeer)ObjectUtils.DeserializeObject(br);
            ToId = (TLAbsPeer)ObjectUtils.DeserializeObject(br);
            Distance = br.ReadInt32();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ObjectUtils.SerializeObject(FromId, bw);
            ObjectUtils.SerializeObject(ToId, bw);
            bw.Write(Distance);

        }
    }
}
