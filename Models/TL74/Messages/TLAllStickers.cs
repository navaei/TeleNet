using System.IO;
using TeleNet.Models.TL.Messages;

namespace TeleNet.Models.TL.Messages
{
    [TLObject(-302170017)]
    public class TLAllStickers : TLAbsAllStickers
    {
        public override int Constructor
        {
            get
            {
                return -302170017;
            }
        }

        public int Hash { get; set; }
        public TLVector<TLStickerSet> Sets { get; set; }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Hash = br.ReadInt32();
            Sets = (TLVector<TLStickerSet>)ObjectUtils.DeserializeVector<TLStickerSet>(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(Hash);
            ObjectUtils.SerializeObject(Sets, bw);

        }
    }
}
