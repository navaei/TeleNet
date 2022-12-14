using System.IO;

namespace  TeleNet.Models.TL85.Account
{
	[TLObject(-2128640689)]
    public class TLSentEmailCode : TLObject
    {
        public override int Constructor
        {
            get
            {
                return -2128640689;
            }
        }

             public string EmailPattern {get;set;}
     public int Length {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            EmailPattern = StringUtil.Deserialize(br);
Length = br.ReadInt32();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            StringUtil.Serialize(EmailPattern,bw);
bw.Write(Length);

        }
    }
}
