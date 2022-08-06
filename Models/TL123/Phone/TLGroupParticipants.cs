using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL123.Phone
{
    [TLObject(-1661028051)]
    public class TLGroupParticipants : TLObject
    {
        public override int Constructor
        {
            get
            {
                return -1661028051;
            }
        }

        public int Count { get; set; }
        public TLVector<TLGroupCallParticipant> Participants { get; set; }
        public string NextOffset { get; set; }
        public TLVector<TLAbsUser> Users { get; set; }
        public int Version { get; set; }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Count = br.ReadInt32();
            Participants = (TLVector<TLGroupCallParticipant>)ObjectUtils.DeserializeVector<TLGroupCallParticipant>(br);
            NextOffset = StringUtil.Deserialize(br);
            Users = (TLVector<TLAbsUser>)ObjectUtils.DeserializeVector<TLAbsUser>(br);
            Version = br.ReadInt32();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(Count);
            ObjectUtils.SerializeObject(Participants, bw);
            StringUtil.Serialize(NextOffset, bw);
            ObjectUtils.SerializeObject(Users, bw);
            bw.Write(Version);

        }
    }
}
