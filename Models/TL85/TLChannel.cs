using System.IO;
using TeleNet.Models.TL;

namespace  TeleNet.Models.TL85
{
    [TLObject(-930515796)]
    public class TLChannel : TLAbsChat
    {
        public override int Constructor
        {
            get
            {
                return -930515796;
            }
        }

        public long? AccessHash { get; set; }
        public bool Signatures { get; set; }
        public bool Min { get; set; }

        public string RestrictionReason { get; set; }



        public void ComputeFlags()
        {
            Flags = 0;
            Flags = Creator ? (Flags | 1) : (Flags & ~1);
            Flags = Left ? (Flags | 4) : (Flags & ~4);
            Flags = Editor ? (Flags | 8) : (Flags & ~8);
            Flags = Broadcast ? (Flags | 32) : (Flags & ~32);
            Flags = Verified ? (Flags | 128) : (Flags & ~128);
            Flags = Megagroup ? (Flags | 256) : (Flags & ~256);
            Flags = Restricted ? (Flags | 512) : (Flags & ~512);
            Flags = Democracy ? (Flags | 1024) : (Flags & ~1024);
            Flags = Signatures ? (Flags | 2048) : (Flags & ~2048);
            Flags = Min ? (Flags | 4096) : (Flags & ~4096);
            Flags = AccessHash != null ? (Flags | 8192) : (Flags & ~8192);
            Flags = Username != null ? (Flags | 64) : (Flags & ~64);
            Flags = RestrictionReason != null ? (Flags | 512) : (Flags & ~512);
            Flags = AdminRights != null ? (Flags | 16384) : (Flags & ~16384);
            Flags = BannedRights != null ? (Flags | 32768) : (Flags & ~32768);
            Flags = ParticipantsCount != null ? (Flags | 131072) : (Flags & ~131072);

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
            Creator = (Flags & 1) != 0;
            Left = (Flags & 4) != 0;
            Editor = (Flags & 8) != 0;
            Broadcast = (Flags & 32) != 0;
            Verified = (Flags & 128) != 0;
            Megagroup = (Flags & 256) != 0;
            Restricted = (Flags & 512) != 0;
            Democracy = (Flags & 1024) != 0;
            Signatures = (Flags & 2048) != 0;
            Min = (Flags & 4096) != 0;
            Id = br.ReadInt32();
            if ((Flags & 8192) != 0)
                AccessHash = br.ReadInt64();
            else
                AccessHash = null;

            Title = StringUtil.Deserialize(br);
            if ((Flags & 64) != 0)
                Username = StringUtil.Deserialize(br);
            else
                Username = null;

            Photo = (TLAbsChatPhoto)ObjectUtils.DeserializeObject(br);
            Date = br.ReadInt32();
            Version = br.ReadInt32();
            if ((Flags & 512) != 0)
                RestrictionReason = StringUtil.Deserialize(br);
            else
                RestrictionReason = null;

            if ((Flags & 16384) != 0)
                AdminRights = (TLAbsChatAdminRights)ObjectUtils.DeserializeObject(br);
            else
                AdminRights = null;

            if ((Flags & 32768) != 0)
                BannedRights = (TLAbsChatBannedRights)ObjectUtils.DeserializeObject(br);
            else
                BannedRights = null;

            if ((Flags & 131072) != 0)
                ParticipantsCount = br.ReadInt32();
            else
                ParticipantsCount = null;


        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ComputeFlags();
            bw.Write(Flags);

            bw.Write(Id);
            if ((Flags & 8192) != 0)
                bw.Write(AccessHash.Value);
            StringUtil.Serialize(Title, bw);
            if ((Flags & 64) != 0)
                StringUtil.Serialize(Username, bw);
            ObjectUtils.SerializeObject(Photo, bw);
            bw.Write(Date);
            bw.Write(Version);
            if ((Flags & 512) != 0)
                StringUtil.Serialize(RestrictionReason, bw);
            if ((Flags & 16384) != 0)
                ObjectUtils.SerializeObject(AdminRights, bw);
            if ((Flags & 32768) != 0)
                ObjectUtils.SerializeObject(BannedRights, bw);
            if ((Flags & 131072) != 0)
                bw.Write(ParticipantsCount.Value);

        }
    }
}
