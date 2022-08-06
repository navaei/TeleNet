using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TeleNet.Models.TL;


namespace TeleNet.Models.TL.Phone
{
    
   
    public abstract class TLAbsGroupParticipants : TLObject
    {
        public int Count { get; set; }
        public TLVector<TLAbsGroupCallParticipant> Participants { get; set; }
        public string NextOffset { get; set; }
        public TLVector<TLAbsUser> Users { get; set; }
        public int Version { get; set; }

    }
}
