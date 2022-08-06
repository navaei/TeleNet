using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL133.Channels
{
    [TLObject(-1095836780)]
    public class TLRequestViewSponsoredMessage : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return -1095836780;
            }
        }

        public TLAbsInputChannel Channel { get; set; }
        public byte[] RandomId { get; set; }
        public bool Response { get; set; }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Channel = (TLAbsInputChannel)ObjectUtils.DeserializeObject(br);
            RandomId = BytesUtil.Deserialize(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ObjectUtils.SerializeObject(Channel, bw);
            BytesUtil.Serialize(RandomId, bw);

        }

        public override void DeserializeResponse(BinaryReader br)
        {
            Response = BoolUtil.Deserialize(br);

        }
    }
}
