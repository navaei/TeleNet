using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL123.Messages
{
    [TLObject(-104078327)]
    public class TLRequestDeletePhoneCallHistory : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return -104078327;
            }
        }

        public int Flags { get; set; }
        public bool Revoke { get; set; }
        public Messages.TLAffectedFoundMessages Response { get; set; }


        public void ComputeFlags()
        {
            Flags = 0;
            Flags = Revoke ? (Flags | 1) : (Flags & ~1);

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
            Revoke = (Flags & 1) != 0;

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ComputeFlags();
            bw.Write(Flags);


        }

        public override void DeserializeResponse(BinaryReader br)
        {
            Response = (Messages.TLAffectedFoundMessages)ObjectUtils.DeserializeObject(br);

        }
    }
}
