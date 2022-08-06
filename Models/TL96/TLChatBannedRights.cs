using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL96
{
    [TLObject(-1626209256)]
    public class TLChatBannedRights : TLAbsChatBannedRights
    {
        public override int Constructor
        {
            get
            {
                return -1626209256;
            }
        }

        public void ComputeFlags()
        {
            Flags = 0;
            Flags = ViewMessages ? (Flags | 1) : (Flags & ~1);
            Flags = SendMessages ? (Flags | 2) : (Flags & ~2);
            Flags = SendMedia ? (Flags | 4) : (Flags & ~4);
            Flags = SendStickers ? (Flags | 8) : (Flags & ~8);
            Flags = SendGifs ? (Flags | 16) : (Flags & ~16);
            Flags = SendGames ? (Flags | 32) : (Flags & ~32);
            Flags = SendInline ? (Flags | 64) : (Flags & ~64);
            Flags = EmbedLinks ? (Flags | 128) : (Flags & ~128);
            Flags = SendPolls ? (Flags | 256) : (Flags & ~256);
            Flags = ChangeInfo ? (Flags | 1024) : (Flags & ~1024);
            Flags = InviteUsers ? (Flags | 32768) : (Flags & ~32768);
            Flags = PinMessages ? (Flags | 131072) : (Flags & ~131072);
        }

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
            ViewMessages = (Flags & 1) != 0;
            SendMessages = (Flags & 2) != 0;
            SendMedia = (Flags & 4) != 0;
            SendStickers = (Flags & 8) != 0;
            SendGifs = (Flags & 16) != 0;
            SendGames = (Flags & 32) != 0;
            SendInline = (Flags & 64) != 0;
            EmbedLinks = (Flags & 128) != 0;
            SendPolls = (Flags & 256) != 0;
            ChangeInfo = (Flags & 1024) != 0;
            InviteUsers = (Flags & 32768) != 0;
            PinMessages = (Flags & 131072) != 0;
            UntilDate = br.ReadInt32();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ComputeFlags();
            bw.Write(Flags);
            bw.Write(UntilDate);

        }
    }
}
