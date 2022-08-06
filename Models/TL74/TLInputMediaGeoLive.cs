using System.IO;

namespace TeleNet.Models.TL
{
	[TLObject(2065305999)]
    public class TLInputMediaGeoLive : TLAbsInputMedia
    {
        public override int Constructor
        {
            get
            {
                return 2065305999;
            }
        }

             public TLAbsInputGeoPoint GeoPoint {get;set;}
     public int Period {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            GeoPoint = (TLAbsInputGeoPoint)ObjectUtils.DeserializeObject(br);
Period = br.ReadInt32();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            ObjectUtils.SerializeObject(GeoPoint,bw);
bw.Write(Period);

        }
    }
}
