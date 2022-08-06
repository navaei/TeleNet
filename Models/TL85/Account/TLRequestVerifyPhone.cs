using System.IO;

namespace  TeleNet.Models.TL85.Account
{
	[TLObject(1305716726)]
    public class TLRequestVerifyPhone : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return 1305716726;
            }
        }

                public string PhoneNumber {get;set;}
        public string PhoneCodeHash {get;set;}
        public string PhoneCode {get;set;}
public bool Response { get; set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            PhoneNumber = StringUtil.Deserialize(br);
PhoneCodeHash = StringUtil.Deserialize(br);
PhoneCode = StringUtil.Deserialize(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            StringUtil.Serialize(PhoneNumber,bw);
StringUtil.Serialize(PhoneCodeHash,bw);
StringUtil.Serialize(PhoneCode,bw);

        }

		public override void DeserializeResponse(BinaryReader br)
		{
			Response = BoolUtil.Deserialize(br);

		}
    }
}
