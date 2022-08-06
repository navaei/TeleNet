using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL133
{
    [TLObject(51520707)]
    public class TLMessageActionChatJoinedByLink : TLAbsMessageAction
    {
        public override int Constructor
        {
            get
            {
                return 51520707;
            }
        }

        public long InviterId { get; set; }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            InviterId = br.ReadInt64();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(InviterId);

        }
    }
}
