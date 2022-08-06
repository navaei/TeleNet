using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;
using  TeleNet.Models.TL96;

namespace  TeleNet.Models.TL111
{
    [TLObject(-1410741723)]
    public class TLInputMediaPoll : TLAbsInputMedia
    {
        public override int Constructor
        {
            get
            {
                return -1410741723;
            }
        }

        public int Flags { get; set; }
        public TLAbsPoll Poll { get; set; }
        public TLVector<byte[]> CorrectAnswers { get; set; }


        public void ComputeFlags()
        {
            Flags = 0;
            Flags = CorrectAnswers != null ? (Flags | 1) : (Flags & ~1);

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
            Poll = (TLAbsPoll)ObjectUtils.DeserializeObject(br);
            if ((Flags & 1) != 0)
                CorrectAnswers = (TLVector<byte[]>)ObjectUtils.DeserializeVector<byte[]>(br);
            else
                CorrectAnswers = null;


        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ComputeFlags();
            bw.Write(Flags);
            ObjectUtils.SerializeObject(Poll, bw);
            if ((Flags & 1) != 0)
                ObjectUtils.SerializeObject(CorrectAnswers, bw);

        }
    }
}
