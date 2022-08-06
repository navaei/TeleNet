using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL123.Phone
{
    [TLObject(-1511559976)]
    public class TLRequestEditGroupCallMember : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return -1511559976;
            }
        }

        public int Flags { get; set; }
        public bool Muted { get; set; }
        public TLInputGroupCall Call { get; set; }
        public TLAbsInputUser UserId { get; set; }
        public int? Volume { get; set; }
        public TLAbsUpdates Response { get; set; }


        public void ComputeFlags()
        {
            Flags = 0;
            Flags = Muted ? (Flags | 1) : (Flags & ~1);
            Flags = Volume != null ? (Flags | 2) : (Flags & ~2);

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
            Muted = (Flags & 1) != 0;
            Call = (TLInputGroupCall)ObjectUtils.DeserializeObject(br);
            UserId = (TLAbsInputUser)ObjectUtils.DeserializeObject(br);
            if ((Flags & 2) != 0)
                Volume = br.ReadInt32();
            else
                Volume = null;


        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ComputeFlags();
            bw.Write(Flags);

            ObjectUtils.SerializeObject(Call, bw);
            ObjectUtils.SerializeObject(UserId, bw);
            if ((Flags & 2) != 0)
                bw.Write(Volume.Value);

        }

        public override void DeserializeResponse(BinaryReader br)
        {
            Response = (TLAbsUpdates)ObjectUtils.DeserializeObject(br);

        }
    }
}
