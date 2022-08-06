using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL133.Messages
{
    [TLObject(-1111085620)]
    public class TLExportedChatInvites : TLObject
    {
        public override int Constructor
        {
            get
            {
                return -1111085620;
            }
        }

        public int Count { get; set; }
        public TLVector<TL.TLAbsExportedChatInvite> Invites { get; set; }
        public TLVector<TLAbsUser> Users { get; set; }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Count = br.ReadInt32();
            Invites = ObjectUtils.DeserializeVector<TL.TLAbsExportedChatInvite>(br);
            Users = ObjectUtils.DeserializeVector<TLAbsUser>(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(Count);
            ObjectUtils.SerializeObject(Invites, bw);
            ObjectUtils.SerializeObject(Users, bw);

        }
    }
}
