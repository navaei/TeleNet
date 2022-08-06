using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL123.Messages
{
    [TLObject(1271290010)]
    public class TLRequestSearchGlobal : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return 1271290010;
            }
        }

        public int Flags { get; set; }
        public int? FolderId { get; set; }
        public string Q { get; set; }
        public TLAbsMessagesFilter Filter { get; set; }
        public int MinDate { get; set; }
        public int MaxDate { get; set; }
        public int OffsetRate { get; set; }
        public TLAbsInputPeer OffsetPeer { get; set; }
        public int OffsetId { get; set; }
        public int Limit { get; set; }
        public TL.Messages.TLAbsMessages Response { get; set; }

        public void ComputeFlags()
        {
            Flags = 0;
            Flags = FolderId != null ? (Flags | 1) : (Flags & ~1);

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
            if ((Flags & 1) != 0)
                FolderId = br.ReadInt32();
            else
                FolderId = null;

            Q = StringUtil.Deserialize(br);
            Filter = (TLAbsMessagesFilter)ObjectUtils.DeserializeObject(br);
            MinDate = br.ReadInt32();
            MaxDate = br.ReadInt32();
            OffsetRate = br.ReadInt32();
            OffsetPeer = (TLAbsInputPeer)ObjectUtils.DeserializeObject(br);
            OffsetId = br.ReadInt32();
            Limit = br.ReadInt32();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ComputeFlags();
            bw.Write(Flags);
            if ((Flags & 1) != 0)
                bw.Write(FolderId.Value);
            StringUtil.Serialize(Q, bw);
            ObjectUtils.SerializeObject(Filter, bw);
            bw.Write(MinDate);
            bw.Write(MaxDate);
            bw.Write(OffsetRate);
            ObjectUtils.SerializeObject(OffsetPeer, bw);
            bw.Write(OffsetId);
            bw.Write(Limit);

        }

        public override void DeserializeResponse(BinaryReader br)
        {
            Response = (TeleNet.Models.TL.Messages.TLAbsMessages)ObjectUtils.DeserializeObject(br);
        }
    }
}
