using System;
using System.Collections.Generic;
using System.Text;

namespace TeleNet.Models.TL
{
    public abstract class TLAbsInputPeerNotifySettings: TLObject
    {
        public int Flags { get; set; }
        public bool? ShowPreviews { get; set; }
        public bool? Silent { get; set; }
        public int? MuteUntil { get; set; }
    }
}
