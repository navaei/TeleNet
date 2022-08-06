using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL140.Messages
{
    [TLObject(-928977804)]
    public class TLRequestGetStickerSet : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return -928977804;
            }
        }

        public TLAbsInputStickerSet Stickerset { get; set; }
        public int Hash { get; set; }
        public TL.Messages.TLStickerSet Response { get; set; }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Stickerset = (TLAbsInputStickerSet)ObjectUtils.DeserializeObject(br);
            Hash = br.ReadInt32();
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ObjectUtils.SerializeObject(Stickerset, bw);
            bw.Write(Hash);
        }

        public override void DeserializeResponse(BinaryReader br)
        {
            Response = (TL.Messages.TLStickerSet)ObjectUtils.DeserializeObject(br);
        }
    }
}
