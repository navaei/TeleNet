using System.IO;

namespace TeleNet.Models.TL
{
	[TLObject(-1141711456)]
    public class TLSecurePasswordKdfAlgoPBKDF2HMACSHA512iter100000 : TLAbsSecurePasswordKdfAlgo
    {
        public override int Constructor
        {
            get
            {
                return -1141711456;
            }
        }

             public byte[] Salt {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Salt = BytesUtil.Deserialize(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            BytesUtil.Serialize(Salt,bw);

        }
    }
}
