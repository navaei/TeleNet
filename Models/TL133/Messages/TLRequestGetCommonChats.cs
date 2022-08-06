using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL133.Messages
{
    [TLObject(-468934396)]
    public class TLRequestGetCommonChats : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return -468934396;
            }
        }

        public TLAbsInputUser UserId { get; set; }
        public long MaxId { get; set; }
        public int Limit { get; set; }
        public TeleNet.Models.TL.Messages.TLAbsChats Response { get; set; }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            UserId = (TLAbsInputUser)ObjectUtils.DeserializeObject(br);
            MaxId = br.ReadInt64();
            Limit = br.ReadInt32();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ObjectUtils.SerializeObject(UserId, bw);
            bw.Write(MaxId);
            bw.Write(Limit);

        }

        public override void DeserializeResponse(BinaryReader br)
        {
            Response = ( TeleNet.Models.TL.Messages.TLAbsChats)ObjectUtils.DeserializeObject(br);

        }
    }
}
