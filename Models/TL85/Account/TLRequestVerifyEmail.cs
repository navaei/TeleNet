using System.IO;

namespace  TeleNet.Models.TL85.Account
{
	[TLObject(-323339813)]
    public class TLRequestVerifyEmail : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return -323339813;
            }
        }

                public string Email {get;set;}
        public string Code {get;set;}
public bool Response { get; set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Email = StringUtil.Deserialize(br);
Code = StringUtil.Deserialize(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            StringUtil.Serialize(Email,bw);
StringUtil.Serialize(Code,bw);

        }

		public override void DeserializeResponse(BinaryReader br)
		{
			Response = BoolUtil.Deserialize(br);

		}
    }
}
