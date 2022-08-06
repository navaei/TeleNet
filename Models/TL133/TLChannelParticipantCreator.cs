using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL133
{
    [TLObject(803602899)]
    public class TLChannelParticipantCreator : TLAbsChannelParticipant
    {
        public override int Constructor
        {
            get
            {
                return 803602899;
            }
        }

        public int Flags { get; set; }
        public long UserId { get; set; }
        public TLAbsChatAdminRights AdminRights { get; set; }
        public string Rank { get; set; }


        public void ComputeFlags()
        {
            Flags = 0;
            Flags = Rank != null ? (Flags | 1) : (Flags & ~1);

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
            UserId = br.ReadInt64();
            AdminRights = (TLAbsChatAdminRights)ObjectUtils.DeserializeObject(br);
            if ((Flags & 1) != 0)
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
            ObjectUtils.SerializeObject(AdminRights, bw);
            if ((Flags & 1) != 0)
                StringUtil.Serialize(Rank, bw);

        }
    }
}
