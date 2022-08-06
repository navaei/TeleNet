using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL140.Messages
{
    [TLObject(-1110823051)]
    public class TLRequestEditExportedChatInvite : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return -1110823051;
            }
        }

        public int Flags { get; set; }
        public bool Revoked { get; set; }
        public TLAbsInputPeer Peer { get; set; }
        public string Link { get; set; }
        public int? ExpireDate { get; set; }
        public int? UsageLimit { get; set; }
        public bool? RequestNeeded { get; set; }
        public string Title { get; set; }
        public TL133.Messages.TLAbsExportedChatInvite Response { get; set; }


        public void ComputeFlags()
        {
            Flags = 0;
            Flags = Revoked ? (Flags | 4) : (Flags & ~4);
            Flags = ExpireDate != null ? (Flags | 1) : (Flags & ~1);
            Flags = UsageLimit != null ? (Flags | 2) : (Flags & ~2);
            Flags = RequestNeeded != null ? (Flags | 8) : (Flags & ~8);
            Flags = Title != null ? (Flags | 16) : (Flags & ~16);

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
            Revoked = (Flags & 4) != 0;
            Peer = (TLAbsInputPeer)ObjectUtils.DeserializeObject(br);
            Link = StringUtil.Deserialize(br);
            if ((Flags & 1) != 0)
                ExpireDate = br.ReadInt32();
            else
                ExpireDate = null;

            if ((Flags & 2) != 0)
                UsageLimit = br.ReadInt32();
            else
                UsageLimit = null;

            if ((Flags & 8) != 0)
                RequestNeeded = BoolUtil.Deserialize(br);
            else
                RequestNeeded = null;

            if ((Flags & 16) != 0)
                Title = StringUtil.Deserialize(br);
            else
                Title = null;


        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ComputeFlags();
            bw.Write(Flags);

            ObjectUtils.SerializeObject(Peer, bw);
            StringUtil.Serialize(Link, bw);
            if ((Flags & 1) != 0)
                bw.Write(ExpireDate.Value);
            if ((Flags & 2) != 0)
                bw.Write(UsageLimit.Value);
            if ((Flags & 8) != 0)
                BoolUtil.Serialize(RequestNeeded.Value, bw);
            if ((Flags & 16) != 0)
                StringUtil.Serialize(Title, bw);

        }

        public override void DeserializeResponse(BinaryReader br)
        {
            Response = (TL133.Messages.TLAbsExportedChatInvite)ObjectUtils.DeserializeObject(br);

        }
    }
}
