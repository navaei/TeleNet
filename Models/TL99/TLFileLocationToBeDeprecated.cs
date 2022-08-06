using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL99
{
    [TLObject(-1132476723)]
    public class TLFileLocationToBeDeprecated : TLAbsFileLocation
    {
        public override int Constructor
        {
            get
            {
                return -1132476723;
            }
        }

        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            VolumeId = br.ReadInt64();
            LocalId = br.ReadInt32();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(VolumeId);
            bw.Write(LocalId);

        }
    }
}
