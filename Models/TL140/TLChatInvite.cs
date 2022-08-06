using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL140
{
    [TLObject(806110401)]
    public class TLChatInvite : TLAbsChatInvite
    {
        public override int Constructor
        {
            get
            {
                return 806110401;
            }
        }

        public string About { get; set; }


        public void ComputeFlags()
        {
            Flags = 0;
            Flags = Channel ? (Flags | 1) : (Flags & ~1);
            Flags = Broadcast ? (Flags | 2) : (Flags & ~2);
            Flags = Public ? (Flags | 4) : (Flags & ~4);
            Flags = Megagroup ? (Flags | 8) : (Flags & ~8);
            Flags = RequestNeeded ? (Flags | 64) : (Flags & ~64);
            Flags = About != null ? (Flags | 32) : (Flags & ~32);
            Flags = Participants != null ? (Flags | 16) : (Flags & ~16);
        }

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
            Channel = (Flags & 1) != 0;
            Broadcast = (Flags & 2) != 0;
            Public = (Flags & 4) != 0;
            Megagroup = (Flags & 8) != 0;
            RequestNeeded = (Flags & 64) != 0;
            Title = StringUtil.Deserialize(br);
            if ((Flags & 32) != 0)
                About = StringUtil.Deserialize(br);
            else
                About = null;

            Photo = (TLAbsPhoto)ObjectUtils.DeserializeObject(br);
            ParticipantsCount = br.ReadInt32();
            if ((Flags & 16) != 0)
                Participants = (TLVector<TLAbsUser>)ObjectUtils.DeserializeVector<TLAbsUser>(br);
            else
                Participants = null;

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ComputeFlags();
            bw.Write(Flags);

            StringUtil.Serialize(Title, bw);
            if ((Flags & 32) != 0)
                StringUtil.Serialize(About, bw);
            ObjectUtils.SerializeObject(Photo, bw);
            bw.Write(ParticipantsCount);
            if ((Flags & 16) != 0)
                ObjectUtils.SerializeObject(Participants, bw);

        }
    }
}
