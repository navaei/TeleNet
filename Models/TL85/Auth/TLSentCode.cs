using System.IO;
using TeleNet.Models.TL.Auth;

namespace  TeleNet.Models.TL85.Auth
{
    [TLObject(955951967)]
    public class TLSentCode : TLAbsSentCode
    {
        public override int Constructor
        {
            get
            {
                return 955951967;
            }
        }

        public Help.TLTermsOfService TermsOfService { get; set; }

        public void ComputeFlags()
        {
            Flags = 0;
            Flags = PhoneRegistered ? (Flags | 1) : (Flags & ~1);
            Flags = NextType != null ? (Flags | 2) : (Flags & ~2);
            Flags = Timeout != null ? (Flags | 4) : (Flags & ~4);
            Flags = TermsOfService != null ? (Flags | 8) : (Flags & ~8);

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
            PhoneRegistered = (Flags & 1) != 0;
            Type = (TeleNet.Models.TL.Auth.TLAbsSentCodeType)ObjectUtils.DeserializeObject(br);
            PhoneCodeHash = StringUtil.Deserialize(br);
            if ((Flags & 2) != 0)
                NextType = (TeleNet.Models.TL.Auth.TLAbsCodeType)ObjectUtils.DeserializeObject(br);
            else
                NextType = null;

            if ((Flags & 4) != 0)
                Timeout = br.ReadInt32();
            else
                Timeout = null;

            if ((Flags & 8) != 0)
                TermsOfService = (Help.TLTermsOfService)ObjectUtils.DeserializeObject(br);
            else
                TermsOfService = null;


        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ComputeFlags();
            bw.Write(Flags);

            ObjectUtils.SerializeObject(Type, bw);
            StringUtil.Serialize(PhoneCodeHash, bw);
            if ((Flags & 2) != 0)
                ObjectUtils.SerializeObject(NextType, bw);
            if ((Flags & 4) != 0)
                bw.Write(Timeout.Value);
            if ((Flags & 8) != 0)
                ObjectUtils.SerializeObject(TermsOfService, bw);

        }
    }
}
