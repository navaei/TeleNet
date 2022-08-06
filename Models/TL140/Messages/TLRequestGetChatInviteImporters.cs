using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL140.Messages
{
    [TLObject(-553329330)]
    public class TLRequestGetChatInviteImporters : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return -553329330;
            }
        }

        public int Flags { get; set; }
        public bool Requested { get; set; }
        public TLAbsInputPeer Peer { get; set; }
        public string Link { get; set; }
        public string Q { get; set; }
        public int OffsetDate { get; set; }
        public TLAbsInputUser OffsetUser { get; set; }
        public int Limit { get; set; }
        public TL133.Messages.TLChatInviteImporters Response { get; set; }


        public void ComputeFlags()
        {
            Flags = 0;
            Flags = Requested ? (Flags | 1) : (Flags & ~1);
            Flags = Link != null ? (Flags | 2) : (Flags & ~2);
            Flags = Q != null ? (Flags | 4) : (Flags & ~4);

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
            Requested = (Flags & 1) != 0;
            Peer = (TLAbsInputPeer)ObjectUtils.DeserializeObject(br);
            if ((Flags & 2) != 0)
                Link = StringUtil.Deserialize(br);
            else
                Link = null;

            if ((Flags & 4) != 0)
                Q = StringUtil.Deserialize(br);
            else
                Q = null;

            OffsetDate = br.ReadInt32();
            OffsetUser = (TLAbsInputUser)ObjectUtils.DeserializeObject(br);
            Limit = br.ReadInt32();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ComputeFlags();
            bw.Write(Flags);

            ObjectUtils.SerializeObject(Peer, bw);
            if ((Flags & 2) != 0)
                StringUtil.Serialize(Link, bw);
            if ((Flags & 4) != 0)
                StringUtil.Serialize(Q, bw);
            bw.Write(OffsetDate);
            ObjectUtils.SerializeObject(OffsetUser, bw);
            bw.Write(Limit);

        }

        public override void DeserializeResponse(BinaryReader br)
        {
            Response = (TL133.Messages.TLChatInviteImporters)ObjectUtils.DeserializeObject(br);

        }
    }
}
