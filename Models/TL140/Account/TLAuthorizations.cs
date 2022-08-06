using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL140.Account
{
    [TLObject(1275039392)]
    public class TLAuthorizations : Models.TL.Account.TLAbsAuthorizations
    {
        public override int Constructor
        {
            get
            {
                return 1275039392;
            }
        }

        public int AuthorizationTtlDays { get; set; }
        public TLVector<TLAbsAuthorization> Authorizations { get; set; }

        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            AuthorizationTtlDays = br.ReadInt32();
            Authorizations = ObjectUtils.DeserializeVector<TLAbsAuthorization>(br);
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(AuthorizationTtlDays);
            ObjectUtils.SerializeObject(Authorizations, bw);

        }
    }
}
