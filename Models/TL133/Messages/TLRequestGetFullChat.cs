using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL133.Messages
{
    [TLObject(-1364194508)]
    public class TLRequestGetFullChat : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return -1364194508;
            }
        }

        public long ChatId { get; set; }
        public TeleNet.Models.TL.Messages.TLChatFull Response { get; set; }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            ChatId = br.ReadInt64();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(ChatId);

        }

        public override void DeserializeResponse(BinaryReader br)
        {
            Response = ( TeleNet.Models.TL.Messages.TLChatFull)ObjectUtils.DeserializeObject(br);

        }
    }
}
