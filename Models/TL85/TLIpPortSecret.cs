using System.IO;

namespace  TeleNet.Models.TL85
{
	[TLObject(932718150)]
    public class TLIpPortSecret : TLAbsIpPort
    {
        public override int Constructor
        {
            get
            {
                return 932718150;
            }
        }

             public int Ipv4 {get;set;}
     public int Port {get;set;}
     public byte[] Secret {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Ipv4 = br.ReadInt32();
Port = br.ReadInt32();
Secret = BytesUtil.Deserialize(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            bw.Write(Ipv4);
bw.Write(Port);
BytesUtil.Serialize(Secret,bw);

        }
    }
}
