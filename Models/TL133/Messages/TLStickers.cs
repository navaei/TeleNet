using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;
using TeleNet.Models.TL.Messages;

namespace TeleNet.Models.TL133.Messages
{
    [TLObject(816245886)]
    public class TLStickers : TLAbsStickers
    {
        public override int Constructor
        {
            get
            {
                return 816245886;
            }
        }

        public long Hash { get; set; }

        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Hash = br.ReadInt64();
            Stickers = (TLVector<TLAbsDocument>)ObjectUtils.DeserializeVector<TLAbsDocument>(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(Hash);
            ObjectUtils.SerializeObject(Stickers, bw);

        }
    }
}
