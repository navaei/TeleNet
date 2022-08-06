using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;
using  TeleNet.Models.TL96;

namespace  TeleNet.Models.TL111.Account
{
    [TLObject(1705865692)]
    public class TLRequestGetMultiWallPapers : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return 1705865692;
            }
        }

        public TLVector<TLAbsInputWallPaper> Wallpapers { get; set; }
        public TLVector<TL96.TLWallPaper> Response { get; set; }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Wallpapers = (TLVector<TLAbsInputWallPaper>)ObjectUtils.DeserializeVector<TLAbsInputWallPaper>(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ObjectUtils.SerializeObject(Wallpapers, bw);

        }

        public override void DeserializeResponse(BinaryReader br)
        {
            Response = (TLVector<TL96.TLWallPaper>)ObjectUtils.DeserializeVector<TL96.TLWallPaper>(br);

        }
    }
}
