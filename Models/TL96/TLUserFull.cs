using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;
using TeleNet.Models.TL.Contacts;

namespace  TeleNet.Models.TL96
{
    [TLObject(-1901811583)]
    public class TLUserFull : TLAbsUserFull
    {
        public override int Constructor
        {
            get
            {
                return -1901811583;
            }
        }

        public void ComputeFlags()
        {
            Flags = 0;
            Flags = Blocked ? (Flags | 1) : (Flags & ~1);
            Flags = PhoneCallsAvailable ? (Flags | 16) : (Flags & ~16);
            Flags = PhoneCallsPrivate ? (Flags | 32) : (Flags & ~32);
            Flags = CanPinMessage ? (Flags | 128) : (Flags & ~128);
            Flags = About != null ? (Flags | 2) : (Flags & ~2);
            Flags = ProfilePhoto != null ? (Flags | 4) : (Flags & ~4);
            Flags = BotInfo != null ? (Flags | 8) : (Flags & ~8);
            Flags = PinnedMsgId != null ? (Flags | 64) : (Flags & ~64);

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
            Blocked = (Flags & 1) != 0;
            PhoneCallsAvailable = (Flags & 16) != 0;
            PhoneCallsPrivate = (Flags & 32) != 0;
            CanPinMessage = (Flags & 128) != 0;
            User = (TLAbsUser)ObjectUtils.DeserializeObject(br);
            if ((Flags & 2) != 0)
                About = StringUtil.Deserialize(br);
            else
                About = null;

            Link = (TLLink)ObjectUtils.DeserializeObject(br);
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

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ComputeFlags();
            bw.Write(Flags);

            ObjectUtils.SerializeObject(User, bw);
            if ((Flags & 2) != 0)
                StringUtil.Serialize(About, bw);
            ObjectUtils.SerializeObject(Link, bw);
            if ((Flags & 4) != 0)
                ObjectUtils.SerializeObject(ProfilePhoto, bw);
            ObjectUtils.SerializeObject(NotifySettings, bw);
            if ((Flags & 8) != 0)
                ObjectUtils.SerializeObject(BotInfo, bw);
            if ((Flags & 64) != 0)
                bw.Write(PinnedMsgId.Value);
            bw.Write(CommonChatsCount);

        }
    }
}
