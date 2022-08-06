using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL140
{
    [TLObject(-1460809483)]
    public class TLDialog : Models.TL.TLAbsDialog
    {
        public override int Constructor
        {
            get
            {
                return -1460809483;
            }
        }

        public int UnreadReactionsCount { get; set; }
        public int? FolderId { get; set; }

        public void ComputeFlags()
        {
            Flags = 0;
            Flags = Pinned ? (Flags | 4) : (Flags & ~4);
            Flags = UnreadMark ? (Flags | 8) : (Flags & ~8);
            Flags = Pts != null ? (Flags | 1) : (Flags & ~1);
            Flags = Draft != null ? (Flags | 2) : (Flags & ~2);
            Flags = FolderId != null ? (Flags | 16) : (Flags & ~16);

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
            Pinned = (Flags & 4) != 0;
            UnreadMark = (Flags & 8) != 0;
            Peer = (TLAbsPeer)ObjectUtils.DeserializeObject(br);
            TopMessage = br.ReadInt32();
            ReadInboxMaxId = br.ReadInt32();
            ReadOutboxMaxId = br.ReadInt32();
            UnreadCount = br.ReadInt32();
            UnreadMentionsCount = br.ReadInt32();
            UnreadReactionsCount = br.ReadInt32();
            NotifySettings = (TLAbsPeerNotifySettings)ObjectUtils.DeserializeObject(br);
            if ((Flags & 1) != 0)
                Pts = br.ReadInt32();
            else
                Pts = null;

            if ((Flags & 2) != 0)
                Draft = (TLAbsDraftMessage)ObjectUtils.DeserializeObject(br);
            else
                Draft = null;

            if ((Flags & 16) != 0)
                FolderId = br.ReadInt32();
            else
                FolderId = null;

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ComputeFlags();
            bw.Write(Flags);

            ObjectUtils.SerializeObject(Peer, bw);
            bw.Write(TopMessage);
            bw.Write(ReadInboxMaxId);
            bw.Write(ReadOutboxMaxId);
            bw.Write(UnreadCount);
            bw.Write(UnreadMentionsCount);
            bw.Write(UnreadReactionsCount);
            ObjectUtils.SerializeObject(NotifySettings, bw);
            if ((Flags & 1) != 0)
                bw.Write(Pts.Value);
            if ((Flags & 2) != 0)
                ObjectUtils.SerializeObject(Draft, bw);
            if ((Flags & 16) != 0)
                bw.Write(FolderId.Value);

        }
    }
}
