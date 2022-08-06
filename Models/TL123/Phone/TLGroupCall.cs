using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL123.Phone
{
    [TLObject(1722485756)]
    public class TLGroupCall : TLObject
    {
        public override int Constructor
        {
            get
            {
                return 1722485756;
            }
        }

        public TLAbsGroupCall Call { get; set; }
        public TLVector<TLGroupCallParticipant> Participants { get; set; }
        public string ParticipantsNextOffset { get; set; }
        public TLVector<TLAbsUser> Users { get; set; }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Call = (TLAbsGroupCall)ObjectUtils.DeserializeObject(br);
            Participants = (TLVector<TLGroupCallParticipant>)ObjectUtils.DeserializeVector<TLGroupCallParticipant>(br);
            ParticipantsNextOffset = StringUtil.Deserialize(br);
            Users = (TLVector<TLAbsUser>)ObjectUtils.DeserializeVector<TLAbsUser>(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ObjectUtils.SerializeObject(Call, bw);
            ObjectUtils.SerializeObject(Participants, bw);
            StringUtil.Serialize(ParticipantsNextOffset, bw);
            ObjectUtils.SerializeObject(Users, bw);

        }
    }
}
