using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL123.Phone
{
    [TLObject(209498135)]
    public class TLRequestGetGroupCall : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return 209498135;
            }
        }

        public TLInputGroupCall Call { get; set; }
        public Phone.TLGroupCall Response { get; set; }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Call = (TLInputGroupCall)ObjectUtils.DeserializeObject(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ObjectUtils.SerializeObject(Call, bw);

        }

        public override void DeserializeResponse(BinaryReader br)
        {
            Response = (Phone.TLGroupCall)ObjectUtils.DeserializeObject(br);

        }
    }
}
