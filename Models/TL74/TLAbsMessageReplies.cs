

using System;
using System.Collections.Generic;
using System.Text;

namespace TeleNet.Models.TL
{
   
    public abstract class TLAbsMessageReplies : TLObject
    {
        public int Flags { get; set; }
        public bool Comments { get; set; }
        public int Replies { get; set; }
        public int RepliesPts { get; set; }
        public TLVector<TLAbsPeer> RecentRepliers { get; set; }
        public long? ChannelId { get; set; }
        public int? MaxId { get; set; }
        public int? ReadMaxId { get; set; }
    }
}
