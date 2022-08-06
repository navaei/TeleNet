using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TeleNet.Models.TL;


namespace TeleNet.Models.TL
{
    public abstract class TLAbsSponsoredMessage : TLObject
    {
        public int Flags { get; set; }
        public byte[] RandomId { get; set; }
        public TLAbsPeer FromId { get; set; }
        public string StartParam { get; set; }
        public string Message { get; set; }
        public TLVector<TLAbsMessageEntity> Entities { get; set; }

    }
}
