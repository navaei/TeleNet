using System.IO;

namespace TeleNet.Models.TL
{
	[TLObject(354925740)]
    public class TLSecureSecretSettings : TLObject
    {
        public override int Constructor
        {
            get
            {
                return 354925740;
            }
        }

             public TLAbsSecurePasswordKdfAlgo SecureAlgo {get;set;}
     public byte[] SecureSecret {get;set;}
     public long SecureSecretId {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            SecureAlgo = (TLAbsSecurePasswordKdfAlgo)ObjectUtils.DeserializeObject(br);
SecureSecret = BytesUtil.Deserialize(br);
SecureSecretId = br.ReadInt64();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            ObjectUtils.SerializeObject(SecureAlgo,bw);
BytesUtil.Serialize(SecureSecret,bw);
bw.Write(SecureSecretId);

        }
    }
}
