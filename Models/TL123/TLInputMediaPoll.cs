using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL123
{
    [TLObject(261416433)]
    public class TLInputMediaPoll : TLAbsInputMedia
    {
        public override int Constructor
        {
            get
            {
                return 261416433;
            }
        }

        public int Flags { get; set; }
        public TLAbsPoll Poll { get; set; }
        public TLVector<byte[]> CorrectAnswers { get; set; }
        public string Solution { get; set; }
        public TLVector<TLAbsMessageEntity> SolutionEntities { get; set; }


        public void ComputeFlags()
        {
            Flags = 0;
            Flags = CorrectAnswers != null ? (Flags | 1) : (Flags & ~1);
            Flags = Solution != null ? (Flags | 2) : (Flags & ~2);
            Flags = SolutionEntities != null ? (Flags | 2) : (Flags & ~2);

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
            Poll = (TLAbsPoll)ObjectUtils.DeserializeObject(br);
            if ((Flags & 1) != 0)
                CorrectAnswers = (TLVector<byte[]>)ObjectUtils.DeserializeVector<byte[]>(br);
            else
                CorrectAnswers = null;

            if ((Flags & 2) != 0)
                Solution = StringUtil.Deserialize(br);
            else
                Solution = null;

            if ((Flags & 2) != 0)
                SolutionEntities = (TLVector<TLAbsMessageEntity>)ObjectUtils.DeserializeVector<TLAbsMessageEntity>(br);
            else
                SolutionEntities = null;


        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ComputeFlags();
            bw.Write(Flags);
            ObjectUtils.SerializeObject(Poll, bw);
            if ((Flags & 1) != 0)
                ObjectUtils.SerializeObject(CorrectAnswers, bw);
            if ((Flags & 2) != 0)
                StringUtil.Serialize(Solution, bw);
            if ((Flags & 2) != 0)
                ObjectUtils.SerializeObject(SolutionEntities, bw);

        }
    }
}
