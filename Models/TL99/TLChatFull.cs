using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace  TeleNet.Models.TL99
{
    [TLObject(461151667)]
    public class TLChatFull : TLAbsChatFull
    {
        public override int Constructor
        {
            get
            {
                return 461151667;
            }
        }

        public int Flags { get; set; }
        public bool CanSetUsername { get; set; }
        public int Id { get; set; }
        public string About { get; set; }
        public TLAbsChatParticipants Participants { get; set; }
        public TLAbsPhoto ChatPhoto { get; set; }
        public TLAbsPeerNotifySettings NotifySettings { get; set; }
        public TLAbsExportedChatInvite ExportedInvite { get; set; }
        public TLVector<TLBotInfo> BotInfo { get; set; }
        public int? PinnedMsgId { get; set; }
        public int? FolderId { get; set; }


        public void ComputeFlags()
        {
            Flags = 0;
            Flags = CanSetUsername ? (Flags | 128) : (Flags & ~128);
            Flags = ChatPhoto != null ? (Flags | 4) : (Flags & ~4);
            Flags = BotInfo != null ? (Flags | 8) : (Flags & ~8);
            Flags = PinnedMsgId != null ? (Flags | 64) : (Flags & ~64);
            Flags = FolderId != null ? (Flags | 2048) : (Flags & ~2048);

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
            CanSetUsername = (Flags & 128) != 0;
            Id = br.ReadInt32();
            About = StringUtil.Deserialize(br);
            Participants = (TLAbsChatParticipants)ObjectUtils.DeserializeObject(br);
            if ((Flags & 4) != 0)
                ChatPhoto = (TLAbsPhoto)ObjectUtils.DeserializeObject(br);
            else
                ChatPhoto = null;

            NotifySettings = (TLAbsPeerNotifySettings)ObjectUtils.DeserializeObject(br);
            ExportedInvite = (TLAbsExportedChatInvite)ObjectUtils.DeserializeObject(br);
            if ((Flags & 8) != 0)
                BotInfo = (TLVector<TLBotInfo>)ObjectUtils.DeserializeVector<TLBotInfo>(br);
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
            ObjectUtils.SerializeObject(ExportedInvite, bw);
            if ((Flags & 8) != 0)
                ObjectUtils.SerializeObject(BotInfo, bw);
            if ((Flags & 64) != 0)
                bw.Write(PinnedMsgId.Value);
            if ((Flags & 2048) != 0)
                bw.Write(FolderId.Value);

        }
    }
}
