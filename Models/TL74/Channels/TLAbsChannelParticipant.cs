using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeleNet.Models.TL.Channels
{
    public abstract class TLAbsChannelParticipant : TLObject
    {
        public TeleNet.Models.TL.TLAbsChannelParticipant Participant { get; set; }
        public TLVector<TLAbsChat> Chats { get; set; }
        public TLVector<TLAbsUser> Users { get; set; }
    }
}
