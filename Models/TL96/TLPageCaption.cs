using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL96
{
    [TLObject(1869903447)]
    public class TLPageCaption : TLObject
    {
        public override int Constructor
        {
            get
            {
                return 1869903447;
            }
        }

        public TLAbsRichText Text { get; set; }
        public TLAbsRichText Credit { get; set; }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Text = (TLAbsRichText)ObjectUtils.DeserializeObject(br);
            Credit = (TLAbsRichText)ObjectUtils.DeserializeObject(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ObjectUtils.SerializeObject(Text, bw);
            ObjectUtils.SerializeObject(Credit, bw);

        }
    }
}
