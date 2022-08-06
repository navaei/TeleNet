using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace  TeleNet.Models.TL96
{
	[TLObject(-833715459)]
    public class TLInputMediaGeoLive : TLAbsInputMedia
    {
        public override int Constructor
        {
            get
            {
                return -833715459;
            }
        }

             public int Flags {get;set;}
     public bool Stopped {get;set;}
     public TLAbsInputGeoPoint GeoPoint {get;set;}
     public int? Period {get;set;}


		public void ComputeFlags()
		{
			Flags = 0;
Flags = Stopped ? (Flags | 1) : (Flags & ~1);
Flags = Period != null ? (Flags | 2) : (Flags & ~2);

		}

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
Stopped = (Flags & 1) != 0;
GeoPoint = (TLAbsInputGeoPoint)ObjectUtils.DeserializeObject(br);
if ((Flags & 2) != 0)
Period = br.ReadInt32();
else
Period = null;


        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            ComputeFlags();
bw.Write(Flags);

ObjectUtils.SerializeObject(GeoPoint,bw);
if ((Flags & 2) != 0)
bw.Write(Period.Value);

        }
    }
}
