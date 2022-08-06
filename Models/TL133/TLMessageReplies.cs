using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL133
{
    [TLObject(-2083123262)]
    public class TLMessageReplies : TLAbsMessageReplies
    {
        public override int Constructor
        {
            get
            {
                return -2083123262;
            }
        }



        public void ComputeFlags()
        {
            Flags = 0;
            Flags = Comments ? (Flags | 1) : (Flags & ~1);
            Flags = RecentRepliers != null ? (Flags | 2) : (Flags & ~2);
            Flags = ChannelId != null ? (Flags | 1) : (Flags & ~1);
            Flags = MaxId != null ? (Flags | 4) : (Flags & ~4);
            Flags = ReadMaxId != null ? (Flags | 8) : (Flags & ~8);

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
            Comments = (Flags & 1) != 0;
            Replies = br.ReadInt32();
            RepliesPts = br.ReadInt32();
            if ((Flags & 2) != 0)
                RecentRepliers = (TLVector<TLAbsPeer>)ObjectUtils.DeserializeVector<TLAbsPeer>(br);
            else
                RecentRepliers = null;

            if ((Flags & 1) != 0)
                ChannelId = br.ReadInt64();
            else
                ChannelId = null;

            if ((Flags & 4) != 0)
                MaxId = br.ReadInt32();
            else
                MaxId = null;

            if ((Flags & 8) != 0)
                ReadMaxId = br.ReadInt32();
            else
                ReadMaxId = null;


        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ComputeFlags();
            bw.Write(Flags);

            bw.Write(Replies);
            bw.Write(RepliesPts);
            if ((Flags & 2) != 0)
                ObjectUtils.SerializeObject(RecentRepliers, bw);
            if ((Flags & 1) != 0)
                bw.Write(ChannelId.Value);
            if ((Flags & 4) != 0)
                bw.Write(MaxId.Value);
            if ((Flags & 8) != 0)
                bw.Write(ReadMaxId.Value);

        }
    }
}
