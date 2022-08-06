using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL133
{
    [TLObject(708589599)]
    public class TLSponsoredMessage : TLAbsSponsoredMessage
    {
        public override int Constructor
        {
            get
            {
                return 708589599;
            }
        }

        public void ComputeFlags()
        {
            Flags = 0;
            Flags = StartParam != null ? (Flags | 1) : (Flags & ~1);
            Flags = Entities != null ? (Flags | 2) : (Flags & ~2);

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
            RandomId = BytesUtil.Deserialize(br);
            FromId = (TLAbsPeer)ObjectUtils.DeserializeObject(br);
            if ((Flags & 1) != 0)
                StartParam = StringUtil.Deserialize(br);
            else
                StartParam = null;

            Message = StringUtil.Deserialize(br);
            if ((Flags & 2) != 0)
                Entities = (TLVector<TLAbsMessageEntity>)ObjectUtils.DeserializeVector<TLAbsMessageEntity>(br);
            else
                Entities = null;


        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ComputeFlags();
            bw.Write(Flags);
            BytesUtil.Serialize(RandomId, bw);
            ObjectUtils.SerializeObject(FromId, bw);
            if ((Flags & 1) != 0)
                StringUtil.Serialize(StartParam, bw);
            StringUtil.Serialize(Message, bw);
            if ((Flags & 2) != 0)
                ObjectUtils.SerializeObject(Entities, bw);

        }
    }
}
