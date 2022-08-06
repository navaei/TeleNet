using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL123.Phone
{
    [TLObject(1604095586)]
    public class TLRequestJoinGroupCall : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return 1604095586;
            }
        }

        public int Flags { get; set; }
        public bool Muted { get; set; }
        public TLInputGroupCall Call { get; set; }
        public TLDataJSON Params { get; set; }
        public TLAbsUpdates Response { get; set; }


        public void ComputeFlags()
        {
            Flags = 0;
            Flags = Muted ? (Flags | 1) : (Flags & ~1);

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
            Muted = (Flags & 1) != 0;
            Call = (TLInputGroupCall)ObjectUtils.DeserializeObject(br);
            Params = (TLDataJSON)ObjectUtils.DeserializeObject(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ComputeFlags();
            bw.Write(Flags);

            ObjectUtils.SerializeObject(Call, bw);
            ObjectUtils.SerializeObject(Params, bw);

        }

        public override void DeserializeResponse(BinaryReader br)
        {
            Response = (TLAbsUpdates)ObjectUtils.DeserializeObject(br);

        }
    }
}
