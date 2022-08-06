using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL96
{
    [TLObject(112424539)]
    public class TLInputMediaPoll : TLAbsInputMedia
    {
        public override int Constructor
        {
            get
            {
                return 112424539;
            }
        }

        public TLAbsPoll Poll { get; set; }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Poll = (TLAbsPoll)ObjectUtils.DeserializeObject(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ObjectUtils.SerializeObject(Poll, bw);

        }
    }
}
