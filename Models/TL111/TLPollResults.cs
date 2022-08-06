using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL96;

namespace TeleNet.Models.TL111
{
    [TLObject(-932174686)]
    public class TLPollResults : TLAbsPollResults
    {
        public override int Constructor
        {
            get
            {
                return -932174686;
            }
        }

        public int Flags { get; set; }
        public bool Min { get; set; }
        public TLVector<TL96.TLPollAnswerVoters> Results { get; set; }
        public int? TotalVoters { get; set; }
        public TLVector<int> RecentVoters { get; set; }


        public void ComputeFlags()
        {
            Flags = 0;
            Flags = Min ? (Flags | 1) : (Flags & ~1);
            Flags = Results != null ? (Flags | 2) : (Flags & ~2);
            Flags = TotalVoters != null ? (Flags | 4) : (Flags & ~4);
            Flags = RecentVoters != null ? (Flags | 8) : (Flags & ~8);

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
            Min = (Flags & 1) != 0;
            if ((Flags & 2) != 0)
                Results = (TLVector<TL96.TLPollAnswerVoters>)ObjectUtils.DeserializeVector<TL96.TLPollAnswerVoters>(br);
            else
                Results = null;

            if ((Flags & 4) != 0)
                TotalVoters = br.ReadInt32();
            else
                TotalVoters = null;

            if ((Flags & 8) != 0)
                RecentVoters = (TLVector<int>)ObjectUtils.DeserializeVector<int>(br);
            else
                RecentVoters = null;


        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ComputeFlags();
            bw.Write(Flags);

            if ((Flags & 2) != 0)
                ObjectUtils.SerializeObject(Results, bw);
            if ((Flags & 4) != 0)
                bw.Write(TotalVoters.Value);
            if ((Flags & 8) != 0)
                ObjectUtils.SerializeObject(RecentVoters, bw);

        }
    }
}
