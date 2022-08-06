using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL140.Auth
{
    [TLObject(872119224)]
    public class TLAuthorization : Models.TL.Auth.TLAbsAuthorization
    {
        public override int Constructor
        {
            get
            {
                return 872119224;
            }
        }

        public bool SetupPasswordRequired { get; set; }
        public int? OtherwiseReloginDays { get; set; }


        public void ComputeFlags()
        {
            Flags = 0;
            Flags = SetupPasswordRequired ? (Flags | 2) : (Flags & ~2);
            Flags = OtherwiseReloginDays != null ? (Flags | 2) : (Flags & ~2);
            Flags = TmpSessions != null ? (Flags | 1) : (Flags & ~1);

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
            SetupPasswordRequired = (Flags & 2) != 0;
            if ((Flags & 2) != 0)
                OtherwiseReloginDays = br.ReadInt32();
            else
                OtherwiseReloginDays = null;

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

            if ((Flags & 2) != 0)
                bw.Write(OtherwiseReloginDays.Value);
            if ((Flags & 1) != 0)
                bw.Write(TmpSessions.Value);
            ObjectUtils.SerializeObject(User, bw);

        }
    }
}
