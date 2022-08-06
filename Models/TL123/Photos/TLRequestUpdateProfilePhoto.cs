using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL123.Photos
{
    [TLObject(1926525996)]
    public class TLRequestUpdateProfilePhoto : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return 1926525996;
            }
        }

        public TLAbsInputPhoto Id { get; set; }
        public TLAbsPhoto Response { get; set; }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Id = (TLAbsInputPhoto)ObjectUtils.DeserializeObject(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ObjectUtils.SerializeObject(Id, bw);

        }

        public override void DeserializeResponse(BinaryReader br)
        {
            Response = (TLAbsPhoto)ObjectUtils.DeserializeObject(br);

        }
    }
}
