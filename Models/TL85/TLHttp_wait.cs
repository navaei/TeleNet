using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL85
{
    [TLObject(-1835453025)]
    public class TLHttp_wait : TLObject
    {
        public override int Constructor
        {
            get
            {
                return -1835453025;
            }
        }

        public int MaxDelay { get; set; }
        public int WaitAfter { get; set; }
        public int MaxWait { get; set; }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            MaxDelay = br.ReadInt32();
            WaitAfter = br.ReadInt32();
            MaxWait = br.ReadInt32();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(MaxDelay);
            bw.Write(WaitAfter);
            bw.Write(MaxWait);

        }
    }
}
