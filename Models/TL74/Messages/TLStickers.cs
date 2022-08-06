using System.IO;
using TeleNet.Models.TL.Messages;

namespace TeleNet.Models.TL.Messages
{
    [TLObject(-1970352846)]
    public class TLStickers : TLAbsStickers
    {
        public override int Constructor
        {
            get
            {
                return -1970352846;
            }
        }

        public string Hash { get; set; }
        public TLVector<TLAbsDocument> Stickers { get; set; }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Hash = StringUtil.Deserialize(br);
            Stickers = (TLVector<TLAbsDocument>)ObjectUtils.DeserializeVector<TLAbsDocument>(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            StringUtil.Serialize(Hash, bw);
            ObjectUtils.SerializeObject(Stickers, bw);

        }
    }
}
