using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeleNet.Models.TL
{
    
   
    public abstract class TLAbsGroupCall : TLObject
    {
        public int Flags { get; set; }
        public long Id { get; set; }
        public long AccessHash { get; set; }
        public int ParticipantsCount { get; set; }

        public bool JoinMuted { get; set; }
        public bool CanChangeJoinMuted { get; set; }
        public bool JoinDateAsc { get; set; }
    }
}
