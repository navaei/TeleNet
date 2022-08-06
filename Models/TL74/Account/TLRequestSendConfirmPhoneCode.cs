using System.IO;
using TeleNet.Models.TL.Auth;

namespace TeleNet.Models.TL.Account
{
    [TLObject(353818557)]
    public class TLRequestSendConfirmPhoneCode : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return 353818557;
            }
        }

        public int Flags { get; set; }
        public bool AllowFlashcall { get; set; }
        public string Hash { get; set; }
        public bool? CurrentNumber { get; set; }
        public TLSentCode Response { get; set; }


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
            Hash = StringUtil.Deserialize(br);
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

            StringUtil.Serialize(Hash, bw);
            if ((Flags & 1) != 0)
                BoolUtil.Serialize(CurrentNumber.Value, bw);

        }
        public override void DeserializeResponse(BinaryReader br)
        {
            Response = (TLSentCode)ObjectUtils.DeserializeObject(br);

        }
    }
}
