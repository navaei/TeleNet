using System.IO;

namespace  TeleNet.Models.TL85
{
	[TLObject(43446532)]
    public class TLGeoPoint : TLObject
    {
        public override int Constructor
        {
            get
            {
                return 43446532;
            }
        }

             public double Long {get;set;}
     public double Lat {get;set;}
     public long AccessHash {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Long = br.ReadDouble();
Lat = br.ReadDouble();
AccessHash = br.ReadInt64();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            bw.Write(Long);
bw.Write(Lat);
bw.Write(AccessHash);

        }
    }
}
