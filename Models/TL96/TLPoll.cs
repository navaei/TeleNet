using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace  TeleNet.Models.TL96
{
    [TLObject(-716006138)]
    public class TLPoll : TLAbsPoll
    {
        public override int Constructor
        {
            get
            {
                return -716006138;
            }
        }

        public long Id { get; set; }
        public int Flags { get; set; }
        public bool Closed { get; set; }
        public string Question { get; set; }
        public TLVector<TLPollAnswer> Answers { get; set; }


        public void ComputeFlags()
        {
            Flags = 0;
            Flags = Closed ? (Flags | 1) : (Flags & ~1);

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Id = br.ReadInt64();
            Flags = br.ReadInt32();
            Closed = (Flags & 1) != 0;
            Question = StringUtil.Deserialize(br);
            Answers = (TLVector<TLPollAnswer>)ObjectUtils.DeserializeVector<TLPollAnswer>(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ComputeFlags();
            bw.Write(Id);
            bw.Write(Flags);

            StringUtil.Serialize(Question, bw);
            ObjectUtils.SerializeObject(Answers, bw);

        }
    }
}
