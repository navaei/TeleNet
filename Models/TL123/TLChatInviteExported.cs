using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL123
{
    [TLObject(1847917725)]
    public class TLChatInviteExported : TLObject
    {
        public override int Constructor
        {
            get
            {
                return 1847917725;
            }
        }

        public int Flags { get; set; }
        public bool Revoked { get; set; }
        public bool Permanent { get; set; }
        public string Link { get; set; }
        public int AdminId { get; set; }
        public int Date { get; set; }
        public int? StartDate { get; set; }
        public int? ExpireDate { get; set; }
        public int? UsageLimit { get; set; }
        public int? Usage { get; set; }


        public void ComputeFlags()
        {
            Flags = 0;
            Flags = Revoked ? (Flags | 1) : (Flags & ~1);
            Flags = Permanent ? (Flags | 32) : (Flags & ~32);
            Flags = StartDate != null ? (Flags | 16) : (Flags & ~16);
            Flags = ExpireDate != null ? (Flags | 2) : (Flags & ~2);
            Flags = UsageLimit != null ? (Flags | 4) : (Flags & ~4);
            Flags = Usage != null ? (Flags | 8) : (Flags & ~8);

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
            Revoked = (Flags & 1) != 0;
            Permanent = (Flags & 32) != 0;
            Link = StringUtil.Deserialize(br);
            AdminId = br.ReadInt32();
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

        }
    }
}
