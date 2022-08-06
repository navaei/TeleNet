using System.IO;

namespace TeleNet.Models.TL
{
	[TLObject(-316748368)]
    public class TLSecureValueHash : TLObject
    {
        public override int Constructor
        {
            get
            {
                return -316748368;
            }
        }

             public TLAbsSecureValueType Type {get;set;}
     public byte[] Hash {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Type = (TLAbsSecureValueType)ObjectUtils.DeserializeObject(br);
Hash = BytesUtil.Deserialize(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            ObjectUtils.SerializeObject(Type,bw);
BytesUtil.Serialize(Hash,bw);

        }
    }
}
