using System.IO;

namespace TeleNet.Models.TL
{
	[TLObject(-734810765)]
    public class TLIpPort : TLAbsIpPort
    {
        public override int Constructor
        {
            get
            {
                return -734810765;
            }
        }

             public int Ipv4 {get;set;}
     public int Port {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Ipv4 = br.ReadInt32();
Port = br.ReadInt32();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            bw.Write(Ipv4);
bw.Write(Port);

        }
    }
}
