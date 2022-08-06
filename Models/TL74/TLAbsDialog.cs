using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeleNet.Models.TL
{
    public abstract class TLAbsDialog : TLObject
    {
        public int Flags { get; set; }
        public bool Pinned { get; set; }
        public bool UnreadMark { get; set; }
        public TLAbsPeer Peer { get; set; }
        public int TopMessage { get; set; }
        public int ReadInboxMaxId { get; set; }
        public int ReadOutboxMaxId { get; set; }
        public int UnreadCount { get; set; }
        public int UnreadMentionsCount { get; set; }
        public TLAbsPeerNotifySettings NotifySettings { get; set; }
        public int? Pts { get; set; }
        public TLAbsDraftMessage Draft { get; set; }
    }
}
