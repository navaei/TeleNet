using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL123
{
	[TLObject(-1768777083)]
    public class TLInputBotInlineMessageMediaGeo : TLObject
    {
        public override int Constructor
        {
            get
            {
                return -1768777083;
            }
        }

             public int Flags {get;set;}
     public TLAbsInputGeoPoint GeoPoint {get;set;}
     public int? Heading {get;set;}
     public int? Period {get;set;}
     public int? ProximityNotificationRadius {get;set;}
     public TLAbsReplyMarkup ReplyMarkup {get;set;}


		public void ComputeFlags()
		{
			Flags = 0;
Flags = Heading != null ? (Flags | 1) : (Flags & ~1);
Flags = Period != null ? (Flags | 2) : (Flags & ~2);
Flags = ProximityNotificationRadius != null ? (Flags | 8) : (Flags & ~8);
Flags = ReplyMarkup != null ? (Flags | 4) : (Flags & ~4);

		}

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
GeoPoint = (TLAbsInputGeoPoint)ObjectUtils.DeserializeObject(br);
if ((Flags & 1) != 0)
Heading = br.ReadInt32();
else
Heading = null;

if ((Flags & 2) != 0)
Period = br.ReadInt32();
else
Period = null;

if ((Flags & 8) != 0)
ProximityNotificationRadius = br.ReadInt32();
else
ProximityNotificationRadius = null;

if ((Flags & 4) != 0)
ReplyMarkup = (TLAbsReplyMarkup)ObjectUtils.DeserializeObject(br);
else
ReplyMarkup = null;


        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            ComputeFlags();
bw.Write(Flags);
ObjectUtils.SerializeObject(GeoPoint,bw);
if ((Flags & 1) != 0)
bw.Write(Heading.Value);
if ((Flags & 2) != 0)
bw.Write(Period.Value);
if ((Flags & 8) != 0)
bw.Write(ProximityNotificationRadius.Value);
if ((Flags & 4) != 0)
ObjectUtils.SerializeObject(ReplyMarkup,bw);

        }
    }
}
