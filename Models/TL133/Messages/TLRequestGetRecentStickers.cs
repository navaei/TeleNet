using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL133.Messages
{
    [TLObject(-1649852357)]
    public class TLRequestGetRecentStickers : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return -1649852357;
            }
        }

        public int Flags { get; set; }
        public bool Attached { get; set; }
        public long Hash { get; set; }
        public TeleNet.Models.TL.Messages.TLAbsRecentStickers Response { get; set; }


        public void ComputeFlags()
        {
            Flags = 0;
            Flags = Attached ? (Flags | 1) : (Flags & ~1);

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
            Attached = (Flags & 1) != 0;
            Hash = br.ReadInt64();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ComputeFlags();
            bw.Write(Flags);

            bw.Write(Hash);

        }

        public override void DeserializeResponse(BinaryReader br)
        {
            Response = ( TeleNet.Models.TL.Messages.TLAbsRecentStickers)ObjectUtils.DeserializeObject(br);

        }
    }
}
