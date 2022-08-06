using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL133.Channels
{
    [TLObject(-333377601)]
    public class TLRequestGetSponsoredMessages : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return -333377601;
            }
        }

        public TLAbsInputChannel Channel { get; set; }
        public Messages.TLSponsoredMessages Response { get; set; }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Channel = (TLAbsInputChannel)ObjectUtils.DeserializeObject(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ObjectUtils.SerializeObject(Channel, bw);

        }

        public override void DeserializeResponse(BinaryReader br)
        {
            Response = (Messages.TLSponsoredMessages)ObjectUtils.DeserializeObject(br);

        }
    }
}
