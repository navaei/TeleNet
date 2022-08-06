using System.IO;

namespace TeleNet.Models.TL
{
	[TLObject(871426631)]
    public class TLSecureCredentialsEncrypted : TLObject
    {
        public override int Constructor
        {
            get
            {
                return 871426631;
            }
        }

             public byte[] Data {get;set;}
     public byte[] Hash {get;set;}
     public byte[] Secret {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Data = BytesUtil.Deserialize(br);
Hash = BytesUtil.Deserialize(br);
Secret = BytesUtil.Deserialize(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            BytesUtil.Serialize(Data,bw);
BytesUtil.Serialize(Hash,bw);
BytesUtil.Serialize(Secret,bw);

        }
    }
}
