using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL133
{
    [TLObject(347227392)]
    public class TLUpdateGroupCall : TLAbsUpdate
    {
        public override int Constructor
        {
            get
            {
                return 347227392;
            }
        }

        public long ChatId { get; set; }
        public TLAbsGroupCall Call { get; set; }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            ChatId = br.ReadInt64();
            Call = (TLAbsGroupCall)ObjectUtils.DeserializeObject(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(ChatId);
            ObjectUtils.SerializeObject(Call, bw);

        }
    }
}
