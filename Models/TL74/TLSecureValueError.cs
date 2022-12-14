using System.IO;

namespace TeleNet.Models.TL
{
	[TLObject(-2036501105)]
    public class TLSecureValueError : TLAbsSecureValueError
    {
        public override int Constructor
        {
            get
            {
                return -2036501105;
            }
        }

             public TLAbsSecureValueType Type {get;set;}
     public byte[] Hash {get;set;}
     public string Text {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Type = (TLAbsSecureValueType)ObjectUtils.DeserializeObject(br);
Hash = BytesUtil.Deserialize(br);
Text = StringUtil.Deserialize(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            ObjectUtils.SerializeObject(Type,bw);
BytesUtil.Serialize(Hash,bw);
StringUtil.Serialize(Text,bw);

        }
    }
}
