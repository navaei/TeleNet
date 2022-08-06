using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL133
{
    [TLObject(-571955892)]
    public class TLInputPeerUser : TLAbsInputPeer
    {
        public override int Constructor
        {
            get
            {
                return -571955892;
            }
        }

        public long UserId { get; set; }
        public long AccessHash { get; set; }

        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            UserId = br.ReadInt64();
            AccessHash = br.ReadInt64();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(UserId);
            bw.Write(AccessHash);

        }
    }
}
