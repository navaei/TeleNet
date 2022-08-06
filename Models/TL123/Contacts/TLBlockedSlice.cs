using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;
using TeleNet.Models.TL.Contacts;

namespace TeleNet.Models.TL123.Contacts
{
    [TLObject(-513392236)]
    public class TLBlockedSlice : TLAbsBlocked
    {
        public override int Constructor
        {
            get
            {
                return -513392236;
            }
        }

        public int Count { get; set; }
        public TLVector<TLPeerBlocked> Blocked { get; set; }
        public TLVector<TLAbsChat> Chats { get; set; }
        public TLVector<TLAbsUser> Users { get; set; }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Count = br.ReadInt32();
            Blocked = (TLVector<TLPeerBlocked>)ObjectUtils.DeserializeVector<TLPeerBlocked>(br);
            Chats = (TLVector<TLAbsChat>)ObjectUtils.DeserializeVector<TLAbsChat>(br);
            Users = (TLVector<TLAbsUser>)ObjectUtils.DeserializeVector<TLAbsUser>(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(Count);
            ObjectUtils.SerializeObject(Blocked, bw);
            ObjectUtils.SerializeObject(Chats, bw);
            ObjectUtils.SerializeObject(Users, bw);

        }
    }
}
