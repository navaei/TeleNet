using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL140
{
    [TLObject(900251559)]
    public class TLChannelParticipantSelf : TLAbsChannelParticipant
    {
        public override int Constructor
        {
            get
            {
                return 900251559;
            }
        }

        public int Flags { get; set; }
        public bool ViaRequest { get; set; }
        public long UserId { get; set; }
        public long InviterId { get; set; }

        public void ComputeFlags()
        {
            Flags = 0;
            Flags = ViaRequest ? (Flags | 1) : (Flags & ~1);

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
            ViaRequest = (Flags & 1) != 0;
            UserId = br.ReadInt64();
            InviterId = br.ReadInt64();
            Date = br.ReadInt32();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ComputeFlags();
            bw.Write(Flags);

            bw.Write(UserId);
            bw.Write(InviterId);
            bw.Write(Date);

        }
    }
}
