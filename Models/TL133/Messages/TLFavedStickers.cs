using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL133.Messages
{
    [TLObject(750063767)]
    public class TLFavedStickers : TL.Messages.TLAbsFavedStickers
    {
        public override int Constructor
        {
            get
            {
                return 750063767;
            }
        }

        public long Hash { get; set; }
        public TLVector<TLStickerPack> Packs { get; set; }
        public TLVector<TLAbsDocument> Stickers { get; set; }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Hash = br.ReadInt64();
            Packs = (TLVector<TLStickerPack>)ObjectUtils.DeserializeVector<TLStickerPack>(br);
            Stickers = (TLVector<TLAbsDocument>)ObjectUtils.DeserializeVector<TLAbsDocument>(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(Hash);
            ObjectUtils.SerializeObject(Packs, bw);
            ObjectUtils.SerializeObject(Stickers, bw);

        }
    }
}
