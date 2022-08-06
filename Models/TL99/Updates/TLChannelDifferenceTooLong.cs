using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;
using TeleNet.Models.TL.Messages;

namespace TeleNet.Models.TL99.Updates
{
    [TLObject(-1531132162)]
    public class TLChannelDifferenceTooLong : TLObject
    {
        public override int Constructor
        {
            get
            {
                return -1531132162;
            }
        }

        public int Flags { get; set; }
        public bool Final { get; set; }
        public int? Timeout { get; set; }
        public TLAbsDialog Dialog { get; set; }
        public TLVector<TLAbsMessage> Messages { get; set; }
        public TLVector<TLAbsChat> Chats { get; set; }
        public TLVector<TLAbsUser> Users { get; set; }


        public void ComputeFlags()
        {
            Flags = 0;
            Flags = Final ? (Flags | 1) : (Flags & ~1);
            Flags = Timeout != null ? (Flags | 2) : (Flags & ~2);

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
            Final = (Flags & 1) != 0;
            if ((Flags & 2) != 0)
                Timeout = br.ReadInt32();
            else
                Timeout = null;

            Dialog = (TLAbsDialog)ObjectUtils.DeserializeObject(br);
            Messages = (TLVector<TLAbsMessage>)ObjectUtils.DeserializeVector<TLAbsMessage>(br);
            Chats = (TLVector<TLAbsChat>)ObjectUtils.DeserializeVector<TLAbsChat>(br);
            Users = (TLVector<TLAbsUser>)ObjectUtils.DeserializeVector<TLAbsUser>(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ComputeFlags();
            bw.Write(Flags);

            if ((Flags & 2) != 0)
                bw.Write(Timeout.Value);
            ObjectUtils.SerializeObject(Dialog, bw);
            ObjectUtils.SerializeObject(Messages, bw);
            ObjectUtils.SerializeObject(Chats, bw);
            ObjectUtils.SerializeObject(Users, bw);

        }
    }
}
