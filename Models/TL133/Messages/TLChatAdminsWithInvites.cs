using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL133.Messages
{
    [TLObject(-1231326505)]
    public class TLChatAdminsWithInvites : TLObject
    {
        public override int Constructor
        {
            get
            {
                return -1231326505;
            }
        }

        public TLVector<TLChatAdminWithInvites> Admins { get; set; }
        public TLVector<TLAbsUser> Users { get; set; }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Admins = (TLVector<TLChatAdminWithInvites>)ObjectUtils.DeserializeVector<TLChatAdminWithInvites>(br);
            Users = (TLVector<TLAbsUser>)ObjectUtils.DeserializeVector<TLAbsUser>(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ObjectUtils.SerializeObject(Admins, bw);
            ObjectUtils.SerializeObject(Users, bw);

        }
    }
}
