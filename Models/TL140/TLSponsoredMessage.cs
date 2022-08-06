using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL140
{
    [TLObject(981691896)]
    public class TLSponsoredMessage : TLAbsSponsoredMessage
    {
        public override int Constructor
        {
            get
            {
                return 981691896;
            }
        }

    
        public TLAbsChatInvite ChatInvite { get; set; }
        public string ChatInviteHash { get; set; }
        public int? ChannelPost { get; set; }

        public void ComputeFlags()
        {
            Flags = 0;
            Flags = FromId != null ? (Flags | 8) : (Flags & ~8);
            Flags = ChatInvite != null ? (Flags | 16) : (Flags & ~16);
            Flags = ChatInviteHash != null ? (Flags | 16) : (Flags & ~16);
            Flags = ChannelPost != null ? (Flags | 4) : (Flags & ~4);
            Flags = StartParam != null ? (Flags | 1) : (Flags & ~1);
            Flags = Entities != null ? (Flags | 2) : (Flags & ~2);

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
            RandomId = BytesUtil.Deserialize(br);
            if ((Flags & 8) != 0)
                FromId = (TLAbsPeer)ObjectUtils.DeserializeObject(br);
            else
                FromId = null;

            if ((Flags & 16) != 0)
                ChatInvite = (TLAbsChatInvite)ObjectUtils.DeserializeObject(br);
            else
                ChatInvite = null;

            if ((Flags & 16) != 0)
                ChatInviteHash = StringUtil.Deserialize(br);
            else
                ChatInviteHash = null;

            if ((Flags & 4) != 0)
                ChannelPost = br.ReadInt32();
            else
                ChannelPost = null;

            if ((Flags & 1) != 0)
                StartParam = StringUtil.Deserialize(br);
            else
                StartParam = null;

            Message = StringUtil.Deserialize(br);
            if ((Flags & 2) != 0)
                Entities = (TLVector<TLAbsMessageEntity>)ObjectUtils.DeserializeVector<TLAbsMessageEntity>(br);
            else
                Entities = null;


        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ComputeFlags();
            bw.Write(Flags);
            BytesUtil.Serialize(RandomId, bw);
            if ((Flags & 8) != 0)
                ObjectUtils.SerializeObject(FromId, bw);
            if ((Flags & 16) != 0)
                ObjectUtils.SerializeObject(ChatInvite, bw);
            if ((Flags & 16) != 0)
                StringUtil.Serialize(ChatInviteHash, bw);
            if ((Flags & 4) != 0)
                bw.Write(ChannelPost.Value);
            if ((Flags & 1) != 0)
                StringUtil.Serialize(StartParam, bw);
            StringUtil.Serialize(Message, bw);
            if ((Flags & 2) != 0)
                ObjectUtils.SerializeObject(Entities, bw);

        }
    }
}
