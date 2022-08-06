using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;
using TeleNet.Models.TL111;

namespace TeleNet.Models.TL133
{
    [TLObject(-1973033641)]
    public class TLMessageUserVoteMultiple : TLAbsMessageUserVote
    {
        public override int Constructor
        {
            get
            {
                return -1973033641;
            }
        }

        public long UserId { get; set; }
        public TLVector<byte[]> Options { get; set; }
        public int Date { get; set; }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            UserId = br.ReadInt64();
            Options = (TLVector<byte[]>)ObjectUtils.DeserializeVector<byte[]>(br);
            Date = br.ReadInt32();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(UserId);
            ObjectUtils.SerializeObject(Options, bw);
            bw.Write(Date);

        }
    }
}
