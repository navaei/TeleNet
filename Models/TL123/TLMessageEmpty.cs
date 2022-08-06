using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL123
{
    [TLObject(-1868117372)]
    public class TLMessageEmpty : TLAbsMessage
    {
        public override int Constructor
        {
            get
            {
                return -1868117372;
            }
        }

        public TLAbsPeer PeerId { get; set; }


        public void ComputeFlags()
        {
            Flags = 0;
            Flags = PeerId != null ? (Flags | 1) : (Flags & ~1);

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
            Id = br.ReadInt32();
            if ((Flags & 1) != 0)
                PeerId = (TLAbsPeer)ObjectUtils.DeserializeObject(br);
            else
                PeerId = null;


        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ComputeFlags();
            bw.Write(Flags);
            bw.Write(Id);
            if ((Flags & 1) != 0)
                ObjectUtils.SerializeObject(PeerId, bw);

        }
    }
}
