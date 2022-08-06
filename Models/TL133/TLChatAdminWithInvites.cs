using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL133
{
    [TLObject(-219353309)]
    public class TLChatAdminWithInvites : TLObject
    {
        public override int Constructor
        {
            get
            {
                return -219353309;
            }
        }

        public long AdminId { get; set; }
        public int InvitesCount { get; set; }
        public int RevokedInvitesCount { get; set; }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            AdminId = br.ReadInt64();
            InvitesCount = br.ReadInt32();
            RevokedInvitesCount = br.ReadInt32();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(AdminId);
            bw.Write(InvitesCount);
            bw.Write(RevokedInvitesCount);

        }
    }
}
