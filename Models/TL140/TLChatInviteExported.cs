using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL140
{
    [TLObject(179611673)]
    public class TLChatInviteExported : TLAbsExportedChatInvite
    {
        public override int Constructor
        {
            get
            {
                return 179611673;
            }
        }
        
        public int? Requested { get; set; }
        public string Title { get; set; }
        public bool RequestNeeded { get; set; }



        public void ComputeFlags()
        {
            Flags = 0;
            Flags = Revoked ? (Flags | 1) : (Flags & ~1);
            Flags = Permanent ? (Flags | 32) : (Flags & ~32);
            Flags = RequestNeeded ? (Flags | 64) : (Flags & ~64);
            Flags = StartDate != null ? (Flags | 16) : (Flags & ~16);
            Flags = ExpireDate != null ? (Flags | 2) : (Flags & ~2);
            Flags = UsageLimit != null ? (Flags | 4) : (Flags & ~4);
            Flags = Usage != null ? (Flags | 8) : (Flags & ~8);
            Flags = Requested != null ? (Flags | 128) : (Flags & ~128);
            Flags = Title != null ? (Flags | 256) : (Flags & ~256);

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
            Revoked = (Flags & 1) != 0;
            Permanent = (Flags & 32) != 0;
            RequestNeeded = (Flags & 64) != 0;
            Link = StringUtil.Deserialize(br);
            AdminId = br.ReadInt64();
            Date = br.ReadInt32();
            if ((Flags & 16) != 0)
                StartDate = br.ReadInt32();
            else
                StartDate = null;

            if ((Flags & 2) != 0)
                ExpireDate = br.ReadInt32();
            else
                ExpireDate = null;

            if ((Flags & 4) != 0)
                UsageLimit = br.ReadInt32();
            else
                UsageLimit = null;

            if ((Flags & 8) != 0)
                Usage = br.ReadInt32();
            else
                Usage = null;

            if ((Flags & 128) != 0)
                Requested = br.ReadInt32();
            else
                Requested = null;

            if ((Flags & 256) != 0)
                Title = StringUtil.Deserialize(br);
            else
                Title = null;


        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ComputeFlags();
            bw.Write(Flags);

            StringUtil.Serialize(Link, bw);
            bw.Write(AdminId);
            bw.Write(Date);
            if ((Flags & 16) != 0)
                bw.Write(StartDate.Value);
            if ((Flags & 2) != 0)
                bw.Write(ExpireDate.Value);
            if ((Flags & 4) != 0)
                bw.Write(UsageLimit.Value);
            if ((Flags & 8) != 0)
                bw.Write(Usage.Value);
            if ((Flags & 128) != 0)
                bw.Write(Requested.Value);
            if ((Flags & 256) != 0)
                StringUtil.Serialize(Title, bw);

        }
    }
}
