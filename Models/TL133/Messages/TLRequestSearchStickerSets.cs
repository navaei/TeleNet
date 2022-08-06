using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL133.Messages
{
    [TLObject(896555914)]
    public class TLRequestSearchStickerSets : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return 896555914;
            }
        }

        public int Flags { get; set; }
        public bool ExcludeFeatured { get; set; }
        public string Q { get; set; }
        public long Hash { get; set; }
        public TL.Messages.TLAbsFoundStickerSets Response { get; set; }


        public void ComputeFlags()
        {
            Flags = 0;
            Flags = ExcludeFeatured ? (Flags | 1) : (Flags & ~1);

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
            ExcludeFeatured = (Flags & 1) != 0;
            Q = StringUtil.Deserialize(br);
            Hash = br.ReadInt64();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ComputeFlags();
            bw.Write(Flags);

            StringUtil.Serialize(Q, bw);
            bw.Write(Hash);

        }

        public override void DeserializeResponse(BinaryReader br)
        {
            Response = (TL.Messages.TLAbsFoundStickerSets)ObjectUtils.DeserializeObject(br);

        }
    }
}
