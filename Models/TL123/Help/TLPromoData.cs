using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL123.Help
{
    [TLObject(-1942390465)]
    public class TLPromoData : TLAbsPromoData
    {
        public override int Constructor
        {
            get
            {
                return -1942390465;
            }
        }

        public int Flags { get; set; }
        public bool Proxy { get; set; }
        public int Expires { get; set; }
        public TLAbsPeer Peer { get; set; }
        public TLVector<TLAbsChat> Chats { get; set; }
        public TLVector<TLAbsUser> Users { get; set; }
        public string PsaType { get; set; }
        public string PsaMessage { get; set; }


        public void ComputeFlags()
        {
            Flags = 0;
            Flags = Proxy ? (Flags | 1) : (Flags & ~1);
            Flags = PsaType != null ? (Flags | 2) : (Flags & ~2);
            Flags = PsaMessage != null ? (Flags | 4) : (Flags & ~4);

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
            Proxy = (Flags & 1) != 0;
            Expires = br.ReadInt32();
            Peer = (TLAbsPeer)ObjectUtils.DeserializeObject(br);
            Chats = (TLVector<TLAbsChat>)ObjectUtils.DeserializeVector<TLAbsChat>(br);
            Users = (TLVector<TLAbsUser>)ObjectUtils.DeserializeVector<TLAbsUser>(br);
            if ((Flags & 2) != 0)
                PsaType = StringUtil.Deserialize(br);
            else
                PsaType = null;

            if ((Flags & 4) != 0)
                PsaMessage = StringUtil.Deserialize(br);
            else
                PsaMessage = null;


        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ComputeFlags();
            bw.Write(Flags);

            bw.Write(Expires);
            ObjectUtils.SerializeObject(Peer, bw);
            ObjectUtils.SerializeObject(Chats, bw);
            ObjectUtils.SerializeObject(Users, bw);
            if ((Flags & 2) != 0)
                StringUtil.Serialize(PsaType, bw);
            if ((Flags & 4) != 0)
                StringUtil.Serialize(PsaMessage, bw);

        }
    }
}
