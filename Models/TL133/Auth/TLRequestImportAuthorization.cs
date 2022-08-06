using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL133.Auth
{
    [TLObject(-1518699091)]
    public class TLRequestImportAuthorization : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return -1518699091;
            }
        }

        public long Id { get; set; }
        public byte[] Bytes { get; set; }
        public TeleNet.Models.TL.Auth.TLAbsAuthorization Response { get; set; }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Id = br.ReadInt64();
            Bytes = BytesUtil.Deserialize(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(Id);
            BytesUtil.Serialize(Bytes, bw);

        }

        public override void DeserializeResponse(BinaryReader br)
        {
            Response = ( TeleNet.Models.TL.Auth.TLAbsAuthorization)ObjectUtils.DeserializeObject(br);

        }
    }
}
