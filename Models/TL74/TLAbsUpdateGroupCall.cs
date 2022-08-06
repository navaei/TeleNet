using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TeleNet.Models.TL;


namespace TeleNet.Models.TL
{
    
   
    public abstract class TLAbsUpdateGroupCall : TLObject
    {
        public long ChatId { get; set; }
        public TLAbsGroupCall Call { get; set; }
    }
}
