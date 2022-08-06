using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL133.Messages
{
    //[TLObject(-1506535550)]
    //public class TLDiscussionMessage : TLAbsDiscussionMessage
    //{
    //    public override int Constructor
    //    {
    //        get
    //        {
    //            return -1506535550;
    //        }
    //    }

    //    public void ComputeFlags()
    //    {
    //        Flags = 0;
    //        Flags = MaxId != null ? (Flags | 1) : (Flags & ~1);
    //        Flags = ReadInboxMaxId != null ? (Flags | 2) : (Flags & ~2);
    //        Flags = ReadOutboxMaxId != null ? (Flags | 4) : (Flags & ~4);

    //    }

    //    public override void DeserializeBody(BinaryReader br)
    //    {
    //        Flags = br.ReadInt32();
    //        Messages = (TLVector<TLAbsMessage>)ObjectUtils.DeserializeVector<TLAbsMessage>(br);
    //        if ((Flags & 1) != 0)
    //            MaxId = br.ReadInt32();
    //        else
    //            MaxId = null;

    //        if ((Flags & 2) != 0)
    //            ReadInboxMaxId = br.ReadInt32();
    //        else
    //            ReadInboxMaxId = null;

    //        if ((Flags & 4) != 0)
    //            ReadOutboxMaxId = br.ReadInt32();
    //        else
    //            ReadOutboxMaxId = null;

    //        UnreadCount = br.ReadInt32();
    //        Chats = (TLVector<TLAbsChat>)ObjectUtils.DeserializeVector<TLAbsChat>(br);
    //        Users = (TLVector<TLAbsUser>)ObjectUtils.DeserializeVector<TLAbsUser>(br);

    //    }

    //    public override void SerializeBody(BinaryWriter bw)
    //    {
    //        bw.Write(Constructor);
    //        ComputeFlags();
    //        bw.Write(Flags);
    //        ObjectUtils.SerializeObject(Messages, bw);
    //        if ((Flags & 1) != 0)
    //            bw.Write(MaxId.Value);
    //        if ((Flags & 2) != 0)
    //            bw.Write(ReadInboxMaxId.Value);
    //        if ((Flags & 4) != 0)
    //            bw.Write(ReadOutboxMaxId.Value);
    //        bw.Write(UnreadCount);
    //        ObjectUtils.SerializeObject(Chats, bw);
    //        ObjectUtils.SerializeObject(Users, bw);

    //    }
    //}
}
