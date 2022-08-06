using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;
using TeleNet.Models.TL96;

namespace TeleNet.Models.TL123
{
    [TLObject(-2032041631)]
    public class TLPoll : TLAbsPoll
    {
        public override int Constructor
        {
            get
            {
                return -2032041631;
            }
        }

        public long Id { get; set; }
        public int Flags { get; set; }
        public bool Closed { get; set; }
        public bool PublicVoters { get; set; }
        public bool MultipleChoice { get; set; }
        public bool Quiz { get; set; }
        public string Question { get; set; }
        public TLVector<TLPollAnswer> Answers { get; set; }
        public int? ClosePeriod { get; set; }
        public int? CloseDate { get; set; }


        public void ComputeFlags()
        {
            Flags = 0;
            Flags = Closed ? (Flags | 1) : (Flags & ~1);
            Flags = PublicVoters ? (Flags | 2) : (Flags & ~2);
            Flags = MultipleChoice ? (Flags | 4) : (Flags & ~4);
            Flags = Quiz ? (Flags | 8) : (Flags & ~8);
            Flags = ClosePeriod != null ? (Flags | 16) : (Flags & ~16);
            Flags = CloseDate != null ? (Flags | 32) : (Flags & ~32);

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Id = br.ReadInt64();
            Flags = br.ReadInt32();
            Closed = (Flags & 1) != 0;
            PublicVoters = (Flags & 2) != 0;
            MultipleChoice = (Flags & 4) != 0;
            Quiz = (Flags & 8) != 0;
            Question = StringUtil.Deserialize(br);
            Answers = (TLVector<TLPollAnswer>)ObjectUtils.DeserializeVector<TLPollAnswer>(br);
            if ((Flags & 16) != 0)
                ClosePeriod = br.ReadInt32();
            else
                ClosePeriod = null;

            if ((Flags & 32) != 0)
                CloseDate = br.ReadInt32();
            else
                CloseDate = null;


        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ComputeFlags();
            bw.Write(Flags);
            bw.Write(Id);

            StringUtil.Serialize(Question, bw);
            ObjectUtils.SerializeObject(Answers, bw);
            if ((Flags & 16) != 0)
                bw.Write(ClosePeriod.Value);
            if ((Flags & 32) != 0)
                bw.Write(CloseDate.Value);

        }
    }
}
