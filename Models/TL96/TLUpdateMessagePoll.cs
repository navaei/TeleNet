using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace  TeleNet.Models.TL96
{
    [TLObject(-1398708869)]
    public class TLUpdateMessagePoll : TLAbsUpdate
    {
        public override int Constructor
        {
            get
            {
                return -1398708869;
            }
        }

        public int Flags { get; set; }
        public long PollId { get; set; }
        public TLAbsPoll Poll { get; set; }
        public TLAbsPollResults Results { get; set; }


        public void ComputeFlags()
        {
            Flags = 0;
            Flags = Poll != null ? (Flags | 1) : (Flags & ~1);

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
            PollId = br.ReadInt64();
            if ((Flags & 1) != 0)
                Poll = (TLAbsPoll)ObjectUtils.DeserializeObject(br);
            else
                Poll = null;

            Results = (TLAbsPollResults)ObjectUtils.DeserializeObject(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ComputeFlags();
            bw.Write(Flags);
            bw.Write(PollId);
            if ((Flags & 1) != 0)
                ObjectUtils.SerializeObject(Poll, bw);
            ObjectUtils.SerializeObject(Results, bw);

        }
    }
}
