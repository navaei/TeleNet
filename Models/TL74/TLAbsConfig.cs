using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeleNet.Models.TL
{

    public abstract class TLAbsConfig : TLObject
    {
        public TLVector<TLAbsDcOption> DcOptions { get; set; }
    }
}
