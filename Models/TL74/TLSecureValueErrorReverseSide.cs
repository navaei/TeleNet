using System.IO;

namespace TeleNet.Models.TL
{
	[TLObject(-2037765467)]
    public class TLSecureValueErrorReverseSide : TLAbsSecureValueError
    {
        public override int Constructor
        {
            get
            {
                return -2037765467;
            }
        }

             public TLAbsSecureValueType Type {get;set;}
     public byte[] FileHash {get;set;}
     public string Text {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Type = (TLAbsSecureValueType)ObjectUtils.DeserializeObject(br);
FileHash = BytesUtil.Deserialize(br);
Text = StringUtil.Deserialize(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            ObjectUtils.SerializeObject(Type,bw);
BytesUtil.Serialize(FileHash,bw);
StringUtil.Serialize(Text,bw);

        }
    }
}
