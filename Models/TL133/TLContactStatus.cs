using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL133
{
    [TLObject(383348795)]
    public class TLContactStatus : TLAbsContactStatus
    {
        public override int Constructor
        {
            get
            {
                return 383348795;
            }
        }

        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            UserId = br.ReadInt64();
            Status = (TLAbsUserStatus)ObjectUtils.DeserializeObject(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(UserId);
            ObjectUtils.SerializeObject(Status, bw);

        }
    }
}
