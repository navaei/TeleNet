using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TeleNet.Models.TL;


namespace TeleNet.Models.TL
{
   
    public abstract class TLAbsBotInfo : TLObject
    {
        public long UserId { get; set; }
        public string Description { get; set; }
        public TLVector<TLBotCommand> Commands { get; set; }

    }
}
