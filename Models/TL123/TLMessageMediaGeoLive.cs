using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL123
{
    [TLObject(-1186937242)]
    public class TLMessageMediaGeoLive : TLAbsMessageMedia
    {
        public override int Constructor
        {
            get
            {
                return -1186937242;
            }
        }

        public int Flags { get; set; }
        public TLAbsGeoPoint Geo { get; set; }
        public int? Heading { get; set; }
        public int Period { get; set; }
        public int? ProximityNotificationRadius { get; set; }


        public void ComputeFlags()
        {
            Flags = 0;
            Flags = Heading != null ? (Flags | 1) : (Flags & ~1);
            Flags = ProximityNotificationRadius != null ? (Flags | 2) : (Flags & ~2);

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
            Geo = (TLAbsGeoPoint)ObjectUtils.DeserializeObject(br);
            if ((Flags & 1) != 0)
                Heading = br.ReadInt32();
            else
                Heading = null;

            Period = br.ReadInt32();
            if ((Flags & 2) != 0)
                ProximityNotificationRadius = br.ReadInt32();
            else
                ProximityNotificationRadius = null;


        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ComputeFlags();
            bw.Write(Flags);
            ObjectUtils.SerializeObject(Geo, bw);
            if ((Flags & 1) != 0)
                bw.Write(Heading.Value);
            bw.Write(Period);
            if ((Flags & 2) != 0)
                bw.Write(ProximityNotificationRadius.Value);

        }
    }
}
