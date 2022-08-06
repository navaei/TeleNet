using System.IO;

namespace  TeleNet.Models.TL85.Account
{
	[TLObject(-2110553932)]
    public class TLRequestSendVerifyPhoneCode : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return -2110553932;
            }
        }

                public int Flags {get;set;}
        public bool AllowFlashcall {get;set;}
        public string PhoneNumber {get;set;}
        public bool? CurrentNumber {get;set;}
public Auth.TLSentCode Response { get; set;}


		public void ComputeFlags()
		{
			Flags = 0;
Flags = AllowFlashcall ? (Flags | 1) : (Flags & ~1);
Flags = CurrentNumber != null ? (Flags | 1) : (Flags & ~1);

		}

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
AllowFlashcall = (Flags & 1) != 0;
PhoneNumber = StringUtil.Deserialize(br);
if ((Flags & 1) != 0)
CurrentNumber = BoolUtil.Deserialize(br);
else
CurrentNumber = null;


        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            ComputeFlags();
bw.Write(Flags);

StringUtil.Serialize(PhoneNumber,bw);
if ((Flags & 1) != 0)
BoolUtil.Serialize(CurrentNumber.Value,bw);

        }

		public override void DeserializeResponse(BinaryReader br)
		{
			Response = (Auth.TLSentCode)ObjectUtils.DeserializeObject(br);

		}
    }
}
