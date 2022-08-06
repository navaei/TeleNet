using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL140
{
    [TLObject(1011024320)]
    public class TLAttachMenuBots : TLAbsAttachMenuBots
    {
        public override int Constructor
        {
            get
            {
                return 1011024320;
            }
        }

        public long Hash { get; set; }
        public TLVector<TLAttachMenuBot> Bots { get; set; }
        public TLVector<TLAbsUser> Users { get; set; }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Hash = br.ReadInt64();
            Bots = (TLVector<TLAttachMenuBot>)ObjectUtils.DeserializeVector<TLAttachMenuBot>(br);
            Users = (TLVector<TLAbsUser>)ObjectUtils.DeserializeVector<TLAbsUser>(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(Hash);
            ObjectUtils.SerializeObject(Bots, bw);
            ObjectUtils.SerializeObject(Users, bw);

        }
    }
}
