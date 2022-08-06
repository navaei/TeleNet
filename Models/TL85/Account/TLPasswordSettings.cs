using TeleNet.Models.TL;
using System.IO;

namespace TeleNet.Models.TL85.Account
{
    [TLObject(-1705233435)]
    public class TLPasswordSettings : TLObject
    {
        public override int Constructor
        {
            get
            {
                return -1705233435;
            }
        }

        public int Flags { get; set; }
        public string Email { get; set; }
        public TLSecureSecretSettings SecureSettings { get; set; }


        public void ComputeFlags()
        {
            Flags = 0;
            Flags = Email != null ? (Flags | 1) : (Flags & ~1);
            Flags = SecureSettings != null ? (Flags | 2) : (Flags & ~2);

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
            if ((Flags & 1) != 0)
                Email = StringUtil.Deserialize(br);
            else
                Email = null;

            if ((Flags & 2) != 0)
                SecureSettings = (TLSecureSecretSettings)ObjectUtils.DeserializeObject(br);
            else
                SecureSettings = null;


        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ComputeFlags();
            bw.Write(Flags);
            if ((Flags & 1) != 0)
                StringUtil.Serialize(Email, bw);
            if ((Flags & 2) != 0)
                ObjectUtils.SerializeObject(SecureSettings, bw);

        }
    }
}
