using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;
using TeleNet.Models.TL.Channels;

namespace TeleNet.Models.TL133.Channels
{
    [TLObject(-1699676497)]
    public class TLChannelParticipants : TL.Channels.TLAbsChannelParticipants
    {
        public override int Constructor
        {
            get
            {
                return -1699676497;
            }
        }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Count = br.ReadInt32();
            Participants = ObjectUtils.DeserializeVector< TeleNet.Models.TL.TLAbsChannelParticipant>(br);
            Chats = ObjectUtils.DeserializeVector<TLAbsChat>(br);
            Users = ObjectUtils.DeserializeVector<TLAbsUser>(br);
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(Count);
            ObjectUtils.SerializeObject(Participants, bw);
            ObjectUtils.SerializeObject(Chats, bw);
            ObjectUtils.SerializeObject(Users, bw);

        }
    }
}
