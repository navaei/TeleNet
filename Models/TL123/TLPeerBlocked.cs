using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL123
{
    [TLObject(-386039788)]
    public class TLPeerBlocked : TLObject
    {
        public override int Constructor
        {
            get
            {
                return -386039788;
            }
        }

        public TLAbsPeer PeerId { get; set; }
        public int Date { get; set; }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            PeerId = (TLAbsPeer)ObjectUtils.DeserializeObject(br);
            Date = br.ReadInt32();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ObjectUtils.SerializeObject(PeerId, bw);
            bw.Write(Date);

        }
    }
}
