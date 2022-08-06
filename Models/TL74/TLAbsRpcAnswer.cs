using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TeleNet.Models.TL
{
    public abstract class TLAbsRpcAnswerDrop : TLObject
    {
        public long MsgId { get; set; }
        public int SeqNo { get; set; }
        public int Bytes { get; set; }
    }
}
