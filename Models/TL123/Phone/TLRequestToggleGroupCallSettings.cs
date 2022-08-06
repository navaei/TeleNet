using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL123.Phone
{
    [TLObject(1958458429)]
    public class TLRequestToggleGroupCallSettings : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return 1958458429;
            }
        }

        public int Flags { get; set; }
        public TLInputGroupCall Call { get; set; }
        public bool? JoinMuted { get; set; }
        public TLAbsUpdates Response { get; set; }


        public void ComputeFlags()
        {
            Flags = 0;
            Flags = JoinMuted != null ? (Flags | 1) : (Flags & ~1);

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
            Call = (TLInputGroupCall)ObjectUtils.DeserializeObject(br);
            if ((Flags & 1) != 0)
                JoinMuted = BoolUtil.Deserialize(br);
            else
                JoinMuted = null;


        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ComputeFlags();
            bw.Write(Flags);
            ObjectUtils.SerializeObject(Call, bw);
            if ((Flags & 1) != 0)
                BoolUtil.Serialize(JoinMuted.Value, bw);

        }

        public override void DeserializeResponse(BinaryReader br)
        {
            Response = (TLAbsUpdates)ObjectUtils.DeserializeObject(br);

        }
    }
}
