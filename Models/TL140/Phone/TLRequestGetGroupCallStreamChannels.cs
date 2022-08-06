using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL140.Phone
{
    [TLObject(447879488)]
    public class TLRequestGetGroupCallStreamChannels : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return 447879488;
            }
        }

        public TL123.TLInputGroupCall Call { get; set; }
        public Phone.TLGroupCallStreamChannels Response { get; set; }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Call = (TL123.TLInputGroupCall)ObjectUtils.DeserializeObject(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ObjectUtils.SerializeObject(Call, bw);

        }

        public override void DeserializeResponse(BinaryReader br)
        {
            Response = (Phone.TLGroupCallStreamChannels)ObjectUtils.DeserializeObject(br);

        }
    }
}
