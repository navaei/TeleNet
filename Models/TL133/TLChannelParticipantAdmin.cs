using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL133
{
    [TLObject(885242707)]
    public class TLChannelParticipantAdmin : TLAbsChannelParticipant
    {
        public override int Constructor
        {
            get
            {
                return 885242707;
            }
        }

        public int Flags { get; set; }
        public bool CanEdit { get; set; }
        public bool Self { get; set; }
        public long UserId { get; set; }
        public long? InviterId { get; set; }
        public long PromotedBy { get; set; }
        public TeleNet.Models.TL.TLAbsChatAdminRights AdminRights { get; set; }
        public string Rank { get; set; }


        public void ComputeFlags()
        {
            Flags = 0;
            Flags = CanEdit ? (Flags | 1) : (Flags & ~1);
            Flags = Self ? (Flags | 2) : (Flags & ~2);
            Flags = InviterId != null ? (Flags | 2) : (Flags & ~2);
            Flags = Rank != null ? (Flags | 4) : (Flags & ~4);

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
            CanEdit = (Flags & 1) != 0;
            Self = (Flags & 2) != 0;
            UserId = br.ReadInt64();
            if ((Flags & 2) != 0)
                InviterId = br.ReadInt64();
            else
                InviterId = null;

            PromotedBy = br.ReadInt64();
            Date = br.ReadInt32();
            AdminRights = (TLAbsChatAdminRights)ObjectUtils.DeserializeObject(br);
            if ((Flags & 4) != 0)
                Rank = StringUtil.Deserialize(br);
            else
                Rank = null;


        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ComputeFlags();
            bw.Write(Flags);


            bw.Write(UserId);
            if ((Flags & 2) != 0)
                bw.Write(InviterId.Value);
            bw.Write(PromotedBy);
            bw.Write(Date);
            ObjectUtils.SerializeObject(AdminRights, bw);
            if ((Flags & 4) != 0)
                StringUtil.Serialize(Rank, bw);

        }
    }
}
