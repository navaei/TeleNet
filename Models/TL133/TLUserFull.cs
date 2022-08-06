using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL133
{
    [TLObject(-694681851)]
    public class TLUserFull : TLAbsUserFull
    {
        public override int Constructor
        {
            get
            {
                return -694681851;
            }
        }

        public int? TtlPeriod { get; set; }
        public string ThemeEmoticon { get; set; }


        public void ComputeFlags()
        {
            Flags = 0;
            Flags = Blocked ? (Flags | 1) : (Flags & ~1);
            Flags = PhoneCallsAvailable ? (Flags | 16) : (Flags & ~16);
            Flags = PhoneCallsPrivate ? (Flags | 32) : (Flags & ~32);
            Flags = CanPinMessage ? (Flags | 128) : (Flags & ~128);
            Flags = HasScheduled ? (Flags | 4096) : (Flags & ~4096);
            Flags = VideoCallsAvailable ? (Flags | 8192) : (Flags & ~8192);
            Flags = About != null ? (Flags | 2) : (Flags & ~2);
            Flags = ProfilePhoto != null ? (Flags | 4) : (Flags & ~4);
            Flags = BotInfo != null ? (Flags | 8) : (Flags & ~8);
            Flags = PinnedMsgId != null ? (Flags | 64) : (Flags & ~64);
            Flags = FolderId != null ? (Flags | 2048) : (Flags & ~2048);
            Flags = TtlPeriod != null ? (Flags | 16384) : (Flags & ~16384);
            Flags = ThemeEmoticon != null ? (Flags | 32768) : (Flags & ~32768);

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
            Blocked = (Flags & 1) != 0;
            PhoneCallsAvailable = (Flags & 16) != 0;
            PhoneCallsPrivate = (Flags & 32) != 0;
            CanPinMessage = (Flags & 128) != 0;
            HasScheduled = (Flags & 4096) != 0;
            VideoCallsAvailable = (Flags & 8192) != 0;
            User = (TLAbsUser)ObjectUtils.DeserializeObject(br);
            if ((Flags & 2) != 0)
                About = StringUtil.Deserialize(br);
            else
                About = null;

            Settings = (TLAbsPeerSettings)ObjectUtils.DeserializeObject(br);
            if ((Flags & 4) != 0)
                ProfilePhoto = (TLAbsPhoto)ObjectUtils.DeserializeObject(br);
            else
                ProfilePhoto = null;

            NotifySettings = (TLAbsPeerNotifySettings)ObjectUtils.DeserializeObject(br);
            if ((Flags & 8) != 0)
                BotInfo = (TLAbsBotInfo)ObjectUtils.DeserializeObject(br);
            else
                BotInfo = null;

            if ((Flags & 64) != 0)
                PinnedMsgId = br.ReadInt32();
            else
                PinnedMsgId = null;

            CommonChatsCount = br.ReadInt32();
            if ((Flags & 2048) != 0)
                FolderId = br.ReadInt32();
            else
                FolderId = null;

            if ((Flags & 16384) != 0)
                TtlPeriod = br.ReadInt32();
            else
                TtlPeriod = null;

            if ((Flags & 32768) != 0)
                ThemeEmoticon = StringUtil.Deserialize(br);
            else
                ThemeEmoticon = null;


        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ComputeFlags();
            bw.Write(Flags);






            ObjectUtils.SerializeObject(User, bw);
            if ((Flags & 2) != 0)
                StringUtil.Serialize(About, bw);
            ObjectUtils.SerializeObject(Settings, bw);
            if ((Flags & 4) != 0)
                ObjectUtils.SerializeObject(ProfilePhoto, bw);
            ObjectUtils.SerializeObject(NotifySettings, bw);
            if ((Flags & 8) != 0)
                ObjectUtils.SerializeObject(BotInfo, bw);
            if ((Flags & 64) != 0)
                bw.Write(PinnedMsgId.Value);
            bw.Write(CommonChatsCount);
            if ((Flags & 2048) != 0)
                bw.Write(FolderId.Value);
            if ((Flags & 16384) != 0)
                bw.Write(TtlPeriod.Value);
            if ((Flags & 32768) != 0)
                StringUtil.Serialize(ThemeEmoticon, bw);

        }
    }
}
