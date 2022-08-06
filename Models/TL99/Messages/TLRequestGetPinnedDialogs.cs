using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;
using TeleNet.Models.TL.Messages;

namespace TeleNet.Models.TL99.Messages
{
    [TLObject(-692498958)]
    public class TLRequestGetPinnedDialogs : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return -692498958;
            }
        }

        public int FolderId { get; set; }
        public TLPeerDialogs Response { get; set; }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            FolderId = br.ReadInt32();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(FolderId);

        }

        public override void DeserializeResponse(BinaryReader br)
        {
            Response = (TLPeerDialogs)ObjectUtils.DeserializeObject(br);

        }
    }
}
