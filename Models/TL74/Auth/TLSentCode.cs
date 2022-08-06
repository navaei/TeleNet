using System.IO;
using TeleNet.Models.TL.Auth;

namespace TeleNet.Models.TL.Auth
{
    [TLObject(1577067778)]
    public class TLSentCode : TLAbsSentCode
    {
        public override int Constructor
        {
            get
            {
                return 1577067778;
            }
        }

        public void ComputeFlags()
        {
            Flags = 0;
            Flags = PhoneRegistered ? (Flags | 1) : (Flags & ~1);
            Flags = NextType != null ? (Flags | 2) : (Flags & ~2);
            Flags = Timeout != null ? (Flags | 4) : (Flags & ~4);

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
            PhoneRegistered = (Flags & 1) != 0;
            Type = (TLAbsSentCodeType)ObjectUtils.DeserializeObject(br);
            PhoneCodeHash = StringUtil.Deserialize(br);
            if ((Flags & 2) != 0)
                NextType = (TLAbsCodeType)ObjectUtils.DeserializeObject(br);
            else
                NextType = null;

            if ((Flags & 4) != 0)
                Timeout = br.ReadInt32();
            else
                Timeout = null;


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

        }
    }
}
