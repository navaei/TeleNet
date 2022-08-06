using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL140
{
    [TLObject(-1525149427)]
    public class TLPeerSettings : TLAbsPeerSettings
    {
        public override int Constructor
        {
            get
            {
                return -1525149427;
            }
        }

        public bool RequestChatBroadcast { get; set; }
        public string RequestChatTitle { get; set; }
        public int? RequestChatDate { get; set; }


        public void ComputeFlags()
        {
            Flags = 0;
            Flags = ReportSpam ? (Flags | 1) : (Flags & ~1);
            Flags = AddContact ? (Flags | 2) : (Flags & ~2);
            Flags = BlockContact ? (Flags | 4) : (Flags & ~4);
            Flags = ShareContact ? (Flags | 8) : (Flags & ~8);
            Flags = NeedContactsException ? (Flags | 16) : (Flags & ~16);
            Flags = ReportGeo ? (Flags | 32) : (Flags & ~32);
            Flags = Autoarchived ? (Flags | 128) : (Flags & ~128);
            Flags = InviteMembers ? (Flags | 256) : (Flags & ~256);
            Flags = RequestChatBroadcast ? (Flags | 1024) : (Flags & ~1024);
            Flags = GeoDistance != null ? (Flags | 64) : (Flags & ~64);
            Flags = RequestChatTitle != null ? (Flags | 512) : (Flags & ~512);
            Flags = RequestChatDate != null ? (Flags | 512) : (Flags & ~512);
        }

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
            ReportSpam = (Flags & 1) != 0;
            AddContact = (Flags & 2) != 0;
            BlockContact = (Flags & 4) != 0;
            ShareContact = (Flags & 8) != 0;
            NeedContactsException = (Flags & 16) != 0;
            ReportGeo = (Flags & 32) != 0;
            Autoarchived = (Flags & 128) != 0;
            InviteMembers = (Flags & 256) != 0;
            RequestChatBroadcast = (Flags & 1024) != 0;
            if ((Flags & 64) != 0)
                GeoDistance = br.ReadInt32();
            else
                GeoDistance = null;

            if ((Flags & 512) != 0)
                RequestChatTitle = StringUtil.Deserialize(br);
            else
                RequestChatTitle = null;

            if ((Flags & 512) != 0)
                RequestChatDate = br.ReadInt32();
            else
                RequestChatDate = null;

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ComputeFlags();
            bw.Write(Flags);

            if ((Flags & 64) != 0)
                bw.Write(GeoDistance.Value);
            if ((Flags & 512) != 0)
                StringUtil.Serialize(RequestChatTitle, bw);
            if ((Flags & 512) != 0)
                bw.Write(RequestChatDate.Value);

        }
    }
}
