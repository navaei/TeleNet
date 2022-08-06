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
    [TLObject(-843329861)]
    public class TLAllStickers : TLAbsAllStickers
    {
        public override int Constructor
        {
            get
            {
                return -843329861;
            }
        }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Hash = br.ReadInt64();
            Sets = ObjectUtils.DeserializeVector<TLAbsStickerSet>(br);
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(Hash);
            ObjectUtils.SerializeObject(Sets, bw);

        }
    }
}
