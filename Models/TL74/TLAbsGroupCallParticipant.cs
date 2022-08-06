using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TeleNet.Models.TL;


namespace TeleNet.Models.TL
{
   
    public abstract class TLAbsGroupCallParticipant : TLObject
    {
        public int Flags { get; set; }
        public bool Muted { get; set; }
        public bool Left { get; set; }
        public bool CanSelfUnmute { get; set; }
        public bool JustJoined { get; set; }
        public bool Versioned { get; set; }
        public bool Min { get; set; }
        public bool MutedByYou { get; set; }
        public bool VolumeByAdmin { get; set; }

        public int Date { get; set; }
        public int? ActiveDate { get; set; }
        public int Source { get; set; }
        public int? Volume { get; set; }

    }
}
