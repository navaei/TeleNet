using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;
using TeleNet.Models.TL96;

namespace TeleNet.Models.TL133
{
    [TLObject(1103884886)]
    public class TLChat : TLAbsChat
    {
        public override int Constructor
        {
            get
            {
                return 1103884886;
            }
        }

        public bool Kicked { get; set; }
        public bool Deactivated { get; set; }
        public bool CallActive { get; set; }
        public bool CallNotEmpty { get; set; }
        public TLAbsInputChannel MigratedTo { get; set; }


        public void ComputeFlags()
        {
            Flags = 0;
            Flags = Creator ? (Flags | 1) : (Flags & ~1);
            Flags = Kicked ? (Flags | 2) : (Flags & ~2);
            Flags = Left ? (Flags | 4) : (Flags & ~4);
            Flags = Deactivated ? (Flags | 32) : (Flags & ~32);
            Flags = CallActive ? (Flags | 8388608) : (Flags & ~8388608);
            Flags = CallNotEmpty ? (Flags | 16777216) : (Flags & ~16777216);
            Flags = MigratedTo != null ? (Flags | 64) : (Flags & ~64);
            Flags = AdminRights != null ? (Flags | 16384) : (Flags & ~16384);
            Flags = DefaultBannedRights != null ? (Flags | 262144) : (Flags & ~262144);

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
            Creator = (Flags & 1) != 0;
            Kicked = (Flags & 2) != 0;
            Left = (Flags & 4) != 0;
            Deactivated = (Flags & 32) != 0;
            CallActive = (Flags & 8388608) != 0;
            CallNotEmpty = (Flags & 16777216) != 0;
            Id = br.ReadInt64();
            Title = StringUtil.Deserialize(br);
            Photo = (TLAbsChatPhoto)ObjectUtils.DeserializeObject(br);
            ParticipantsCount = br.ReadInt32();
            Date = br.ReadInt32();
            Version = br.ReadInt32();
            if ((Flags & 64) != 0)
                MigratedTo = (TLAbsInputChannel)ObjectUtils.DeserializeObject(br);
            else
                MigratedTo = null;

            if ((Flags & 16384) != 0)
                AdminRights = (TLChatAdminRights)ObjectUtils.DeserializeObject(br);
            else
                AdminRights = null;

            if ((Flags & 262144) != 0)
                DefaultBannedRights = (TLChatBannedRights)ObjectUtils.DeserializeObject(br);
            else
                DefaultBannedRights = null;


        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ComputeFlags();
            bw.Write(Flags);

            bw.Write(Id);
            StringUtil.Serialize(Title, bw);
            ObjectUtils.SerializeObject(Photo, bw);
            bw.Write(ParticipantsCount ?? 1);
            bw.Write(Date);
            bw.Write(Version);
            if ((Flags & 64) != 0)
                ObjectUtils.SerializeObject(MigratedTo, bw);
            if ((Flags & 16384) != 0)
                ObjectUtils.SerializeObject(AdminRights, bw);
            if ((Flags & 262144) != 0)
                ObjectUtils.SerializeObject(DefaultBannedRights, bw);

        }
    }
}
