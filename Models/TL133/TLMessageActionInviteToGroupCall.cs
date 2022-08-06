using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL133
{
    [TLObject(1345295095)]
    public class TLMessageActionInviteToGroupCall : TLAbsMessageAction
    {
        public override int Constructor
        {
            get
            {
                return 1345295095;
            }
        }

        public TL123.TLInputGroupCall Call { get; set; }
        public TLVector<long> Users { get; set; }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Call = (TL123.TLInputGroupCall)ObjectUtils.DeserializeObject(br);
            Users = (TLVector<long>)ObjectUtils.DeserializeVector<long>(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ObjectUtils.SerializeObject(Call, bw);
            ObjectUtils.SerializeObject(Users, bw);

        }
    }
}
