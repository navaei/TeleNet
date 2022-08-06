using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL133.Messages
{
    [TLObject(-2067782896)]
    public class TLFeaturedStickers : TL.Messages.TLAbsFeaturedStickers
    {
        public override int Constructor
        {
            get
            {
                return -2067782896;
            }
        }

        public long Hash { get; set; }
        public int Count { get; set; }
        public TLVector<TLAbsStickerSetCovered> Sets { get; set; }
        public TLVector<long> Unread { get; set; }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Hash = br.ReadInt64();
            Count = br.ReadInt32();
            Sets = (TLVector<TLAbsStickerSetCovered>)ObjectUtils.DeserializeVector<TLAbsStickerSetCovered>(br);
            Unread = (TLVector<long>)ObjectUtils.DeserializeVector<long>(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(Hash);
            bw.Write(Count);
            ObjectUtils.SerializeObject(Sets, bw);
            ObjectUtils.SerializeObject(Unread, bw);

        }
    }
}
