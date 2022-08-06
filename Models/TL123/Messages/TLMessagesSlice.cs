using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;
using TeleNet.Models.TL.Messages;

namespace TeleNet.Models.TL123.Messages
{
    [TLObject(978610270)]
    public class TLMessagesSlice : TLAbsMessages
    {
        public override int Constructor
        {
            get
            {
                return 978610270;
            }
        }

        public int Flags { get; set; }
        public bool Inexact { get; set; }
        public int Count { get; set; }
        public int? NextRate { get; set; }
        public int? OffsetIdOffset { get; set; }
        public TLVector<TLAbsMessage> Messages { get; set; }
        public TLVector<TLAbsChat> Chats { get; set; }
        public TLVector<TLAbsUser> Users { get; set; }


        public void ComputeFlags()
        {
            Flags = 0;
            Flags = Inexact ? (Flags | 2) : (Flags & ~2);
            Flags = NextRate != null ? (Flags | 1) : (Flags & ~1);
            Flags = OffsetIdOffset != null ? (Flags | 4) : (Flags & ~4);

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
            Inexact = (Flags & 2) != 0;
            Count = br.ReadInt32();
            if ((Flags & 1) != 0)
                NextRate = br.ReadInt32();
            else
                NextRate = null;

            if ((Flags & 4) != 0)
                OffsetIdOffset = br.ReadInt32();
            else
                OffsetIdOffset = null;

            Messages = (TLVector<TLAbsMessage>)ObjectUtils.DeserializeVector<TLAbsMessage>(br);
            Chats = (TLVector<TLAbsChat>)ObjectUtils.DeserializeVector<TLAbsChat>(br);
            Users = (TLVector<TLAbsUser>)ObjectUtils.DeserializeVector<TLAbsUser>(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ComputeFlags();
            bw.Write(Flags);

            bw.Write(Count);
            if ((Flags & 1) != 0)
                bw.Write(NextRate.Value);
            if ((Flags & 4) != 0)
                bw.Write(OffsetIdOffset.Value);
            ObjectUtils.SerializeObject(Messages, bw);
            ObjectUtils.SerializeObject(Chats, bw);
            ObjectUtils.SerializeObject(Users, bw);

        }
    }
}
