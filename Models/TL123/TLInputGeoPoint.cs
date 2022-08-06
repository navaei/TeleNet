using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL123
{
    [TLObject(1210199983)]
    public class TLInputGeoPoint : TLObject
    {
        public override int Constructor
        {
            get
            {
                return 1210199983;
            }
        }

        public int Flags { get; set; }
        public double Lat { get; set; }
        public double Long { get; set; }
        public int? AccuracyRadius { get; set; }


        public void ComputeFlags()
        {
            Flags = 0;
            Flags = AccuracyRadius != null ? (Flags | 1) : (Flags & ~1);

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
            Lat = br.ReadDouble();
            Long = br.ReadDouble();
            if ((Flags & 1) != 0)
                AccuracyRadius = br.ReadInt32();
            else
                AccuracyRadius = null;


        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ComputeFlags();
            bw.Write(Flags);
            bw.Write(Lat);
            bw.Write(Long);
            if ((Flags & 1) != 0)
                bw.Write(AccuracyRadius.Value);

        }
    }
}
