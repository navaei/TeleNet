using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL96
{
    [TLObject(1465219162)]
    public class TLPollResults : TLAbsPollResults
    {
        public override int Constructor
        {
            get
            {
                return 1465219162;
            }
        }

        public int Flags { get; set; }
        public bool Min { get; set; }
        public TLVector<TLPollAnswerVoters> Results { get; set; }
        public int? TotalVoters { get; set; }


        public void ComputeFlags()
        {
            Flags = 0;
            Flags = Min ? (Flags | 1) : (Flags & ~1);
            Flags = Results != null ? (Flags | 2) : (Flags & ~2);
            Flags = TotalVoters != null ? (Flags | 4) : (Flags & ~4);

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
            Min = (Flags & 1) != 0;
            if ((Flags & 2) != 0)
                Results = (TLVector<TLPollAnswerVoters>)ObjectUtils.DeserializeVector<TLPollAnswerVoters>(br);
            else
                Results = null;

            if ((Flags & 4) != 0)
                TotalVoters = br.ReadInt32();
            else
                TotalVoters = null;


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

        }
    }
}
