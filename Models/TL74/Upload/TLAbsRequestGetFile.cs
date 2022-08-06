using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeleNet.Models.TL.Upload
{
    public abstract class TLAbsRequestGetFile : TLMethod
    {
        public TLAbsInputFileLocation Location { get; set; }
        public int Offset { get; set; }
        public int Limit { get; set; }

        public TL.Upload.TLAbsFile Response { get; set; }
    }
}
