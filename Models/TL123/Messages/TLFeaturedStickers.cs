using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;
using TeleNet.Models.TL.Messages;

namespace TeleNet.Models.TL123.Messages
{
    [TLObject(-1230257343)]
    public class TLFeaturedStickers : TLAbsFeaturedStickers
    {
        public override int Constructor
        {
            get
            {
                return -1230257343;
            }
        }

        public int Hash { get; set; }
        public int Count { get; set; }
        public TLVector<TLAbsStickerSetCovered> Sets { get; set; }
        public TLVector<long> Unread { get; set; }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Hash = br.ReadInt32();
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
