using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL133
{
    [TLObject(-1071741569)]
    public class TLUpdateUserTyping : TLAbsUpdate
    {
        public override int Constructor
        {
            get
            {
                return -1071741569;
            }
        }

        public long UserId { get; set; }
        public TLAbsSendMessageAction Action { get; set; }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            UserId = br.ReadInt64();
            Action = (TLAbsSendMessageAction)ObjectUtils.DeserializeObject(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(UserId);
            ObjectUtils.SerializeObject(Action, bw);

        }
    }
}
