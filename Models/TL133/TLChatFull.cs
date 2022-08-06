using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL133
{
    [TLObject(1304281241)]
    public class TLChatFull : TLAbsChatFull
    {
        public override int Constructor
        {
            get
            {
                return 1304281241;
            }
        }

        public bool CanSetUsername { get; set; }
        public bool HasScheduled { get; set; }
        public string About { get; set; }
        public TLAbsChatParticipants Participants { get; set; }
        public TLAbsPhoto ChatPhoto { get; set; }
        public TLAbsPeerNotifySettings NotifySettings { get; set; }
        public TLAbsExportedChatInvite ExportedInvite { get; set; }
        public TLVector<TLAbsBotInfo> BotInfo { get; set; }
        public int? PinnedMsgId { get; set; }
        public int? FolderId { get; set; }
        public TL123.TLInputGroupCall Call { get; set; }
        public int? TtlPeriod { get; set; }
        public TLAbsPeer GroupcallDefaultJoinAs { get; set; }
        public string ThemeEmoticon { get; set; }


        public void ComputeFlags()
        {
            Flags = 0;
            Flags = CanSetUsername ? (Flags | 128) : (Flags & ~128);
            Flags = HasScheduled ? (Flags | 256) : (Flags & ~256);
            Flags = ChatPhoto != null ? (Flags | 4) : (Flags & ~4);
            Flags = ExportedInvite != null ? (Flags | 8192) : (Flags & ~8192);
            Flags = BotInfo != null ? (Flags | 8) : (Flags & ~8);
            Flags = PinnedMsgId != null ? (Flags | 64) : (Flags & ~64);
            Flags = FolderId != null ? (Flags | 2048) : (Flags & ~2048);
            Flags = Call != null ? (Flags | 4096) : (Flags & ~4096);
            Flags = TtlPeriod != null ? (Flags | 16384) : (Flags & ~16384);
            Flags = GroupcallDefaultJoinAs != null ? (Flags | 32768) : (Flags & ~32768);
            Flags = ThemeEmoticon != null ? (Flags | 65536) : (Flags & ~65536);

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
            CanSetUsername = (Flags & 128) != 0;
            HasScheduled = (Flags & 256) != 0;
            Id = br.ReadInt64();
            About = StringUtil.Deserialize(br);
            Participants = (TLAbsChatParticipants)ObjectUtils.DeserializeObject(br);
            if ((Flags & 4) != 0)
                ChatPhoto = (TLAbsPhoto)ObjectUtils.DeserializeObject(br);
            else
                ChatPhoto = null;

            NotifySettings = (TLAbsPeerNotifySettings)ObjectUtils.DeserializeObject(br);
            if ((Flags & 8192) != 0)
                ExportedInvite = (TLAbsExportedChatInvite)ObjectUtils.DeserializeObject(br);
            else
                ExportedInvite = null;

            if ((Flags & 8) != 0)
                BotInfo = ObjectUtils.DeserializeVector<TLAbsBotInfo>(br);
            else
                BotInfo = null;

            if ((Flags & 64) != 0)
                PinnedMsgId = br.ReadInt32();
            else
                PinnedMsgId = null;

            if ((Flags & 2048) != 0)
                FolderId = br.ReadInt32();
            else
                FolderId = null;

            if ((Flags & 4096) != 0)
                Call = (TL123.TLInputGroupCall)ObjectUtils.DeserializeObject(br);
            else
                Call = null;

            if ((Flags & 16384) != 0)
                TtlPeriod = br.ReadInt32();
            else
                TtlPeriod = null;

            if ((Flags & 32768) != 0)
                GroupcallDefaultJoinAs = (TLAbsPeer)ObjectUtils.DeserializeObject(br);
            else
                GroupcallDefaultJoinAs = null;

            if ((Flags & 65536) != 0)
                ThemeEmoticon = StringUtil.Deserialize(br);
            else
                ThemeEmoticon = null;
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ComputeFlags();
            bw.Write(Flags);


            bw.Write(Id);
            StringUtil.Serialize(About, bw);
            ObjectUtils.SerializeObject(Participants, bw);
            if ((Flags & 4) != 0)
                ObjectUtils.SerializeObject(ChatPhoto, bw);
            ObjectUtils.SerializeObject(NotifySettings, bw);
            if ((Flags & 8192) != 0)
                ObjectUtils.SerializeObject(ExportedInvite, bw);
            if ((Flags & 8) != 0)
                ObjectUtils.SerializeObject(BotInfo, bw);
            if ((Flags & 64) != 0)
                bw.Write(PinnedMsgId.Value);
            if ((Flags & 2048) != 0)
                bw.Write(FolderId.Value);
            if ((Flags & 4096) != 0)
                ObjectUtils.SerializeObject(Call, bw);
            if ((Flags & 16384) != 0)
                bw.Write(TtlPeriod.Value);
            if ((Flags & 32768) != 0)
                ObjectUtils.SerializeObject(GroupcallDefaultJoinAs, bw);
            if ((Flags & 65536) != 0)
                StringUtil.Serialize(ThemeEmoticon, bw);

        }
    }
}
