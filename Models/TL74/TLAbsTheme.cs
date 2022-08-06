using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TeleNet.Models.TL;


namespace TeleNet.Models.TL
{
   
    public abstract class TLAbsTheme : TLObject
    {
        public int Flags { get; set; }
        public bool Creator { get; set; }
        public bool Default { get; set; }
        public bool ForChat { get; set; }
        public long Id { get; set; }
        public long AccessHash { get; set; }
        public string Slug { get; set; }
        public string Title { get; set; }
        public TLAbsDocument Document { get; set; }
        public TLAbsThemeSettings Settings { get; set; }
        public int? InstallsCount { get; set; }

    }
}
