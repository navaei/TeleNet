using System.IO;

namespace TeleNet.Models.TL.Account
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

        public int Flags { get; set; }
        public bool AllowFlashcall { get; set; }
        public string PhoneNumber { get; set; }
        public bool? CurrentNumber { get; set; }
        public Auth.TLAbsSentCode Response { get; set; }


        public void ComputeFlags()
        {

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
            bw.Write(Flags);

            StringUtil.Serialize(PhoneNumber, bw);
            if ((Flags & 1) != 0)
                BoolUtil.Serialize(CurrentNumber.Value, bw);

        }
        public override void DeserializeResponse(BinaryReader br)
        {
            Response = (Auth.TLAbsSentCode)ObjectUtils.DeserializeObject(br);

        }
    }
}
