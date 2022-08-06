using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL140.Messages
{
    [TLObject(-1332768214)]
    public class TLRequestDeleteHistory : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return -1332768214;
            }
        }

        public int Flags { get; set; }
        public bool JustClear { get; set; }
        public bool Revoke { get; set; }
        public TLAbsInputPeer Peer { get; set; }
        public int MaxId { get; set; }
        public int? MinDate { get; set; }
        public int? MaxDate { get; set; }
        public TL.Messages.TLAffectedHistory Response { get; set; }


        public void ComputeFlags()
        {
            Flags = 0;
            Flags = JustClear ? (Flags | 1) : (Flags & ~1);
            Flags = Revoke ? (Flags | 2) : (Flags & ~2);
            Flags = MinDate != null ? (Flags | 4) : (Flags & ~4);
            Flags = MaxDate != null ? (Flags | 8) : (Flags & ~8);

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
            JustClear = (Flags & 1) != 0;
            Revoke = (Flags & 2) != 0;
            Peer = (TLAbsInputPeer)ObjectUtils.DeserializeObject(br);
            MaxId = br.ReadInt32();
            if ((Flags & 4) != 0)
                MinDate = br.ReadInt32();
            else
                MinDate = null;

            if ((Flags & 8) != 0)
                MaxDate = br.ReadInt32();
            else
                MaxDate = null;


        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ComputeFlags();
            bw.Write(Flags);


            ObjectUtils.SerializeObject(Peer, bw);
            bw.Write(MaxId);
            if ((Flags & 4) != 0)
                bw.Write(MinDate.Value);
            if ((Flags & 8) != 0)
                bw.Write(MaxDate.Value);

        }

        public override void DeserializeResponse(BinaryReader br)
        {
            Response = (TL.Messages.TLAffectedHistory)ObjectUtils.DeserializeObject(br);

        }
    }
}
