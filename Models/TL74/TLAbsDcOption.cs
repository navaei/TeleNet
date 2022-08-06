using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeleNet.Models.TL
{
   
    public abstract class TLAbsDcOption : TLObject
    {
        public int Flags { get; set; }
        public bool Ipv6 { get; set; }
        public bool MediaOnly { get; set; }
        public bool TcpoOnly { get; set; }
        public bool Cdn { get; set; }
        public bool Static { get; set; }
        public int Id { get; set; }
        public string IpAddress { get; set; }
        public int Port { get; set; }

    }
}
