using System.IO;

namespace TeleNet.Models.TL
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
