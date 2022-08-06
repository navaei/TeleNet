using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL140
{
    [TLObject(1328256121)]
    public class TLMessageReactions : TLObject
    {
        public override int Constructor
        {
            get
            {
                return 1328256121;
            }
        }

        public int Flags { get; set; }
        public bool Min { get; set; }
        public bool CanSeeList { get; set; }
        public TLVector<TLReactionCount> Results { get; set; }
        public TLVector<TLMessagePeerReaction> RecentReactions { get; set; }


        public void ComputeFlags()
        {
            Flags = 0;
            Flags = Min ? (Flags | 1) : (Flags & ~1);
            Flags = CanSeeList ? (Flags | 4) : (Flags & ~4);
            Flags = RecentReactions != null ? (Flags | 2) : (Flags & ~2);

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
            Min = (Flags & 1) != 0;
            CanSeeList = (Flags & 4) != 0;
            Results = (TLVector<TLReactionCount>)ObjectUtils.DeserializeVector<TLReactionCount>(br);
            if ((Flags & 2) != 0)
                RecentReactions = (TLVector<TLMessagePeerReaction>)ObjectUtils.DeserializeVector<TLMessagePeerReaction>(br);
            else
                RecentReactions = null;


        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ComputeFlags();
            bw.Write(Flags);


            ObjectUtils.SerializeObject(Results, bw);
            if ((Flags & 2) != 0)
                ObjectUtils.SerializeObject(RecentReactions, bw);

        }
    }
}
