using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;
using TeleNet.Models.TL.Auth;

namespace TeleNet.Models.TL133.Auth
{
    [TLObject(-1271602504)]
    public class TLExportedAuthorization : TLAbsExportedAuthorization
    {
        public override int Constructor
        {
            get
            {
                return -1271602504;
            }
        }


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
    }
}
