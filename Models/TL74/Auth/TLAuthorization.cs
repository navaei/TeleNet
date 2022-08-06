using System.IO;

namespace TeleNet.Models.TL.Auth
{
    [TLObject(-855308010)]
    public class TLAuthorization : TLAbsAuthorization
    {
        public override int Constructor
        {
            get
            {
                return -855308010;
            }
        }


        public void ComputeFlags()
        {
            Flags = 0;
            Flags = TmpSessions != null ? (Flags | 1) : (Flags & ~1);

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
            if ((Flags & 1) != 0)
                TmpSessions = br.ReadInt32();
            else
                TmpSessions = null;

            User = (TLAbsUser)ObjectUtils.DeserializeObject(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ComputeFlags();
            bw.Write(Flags);
            if ((Flags & 1) != 0)
                bw.Write(TmpSessions.Value);
            ObjectUtils.SerializeObject(User, bw);

        }
    }
}
