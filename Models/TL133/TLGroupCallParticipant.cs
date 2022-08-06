using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL133
{
    [TLObject(-341428482)]
    public class TLGroupCallParticipant : TL.TLAbsGroupCallParticipant
    {
        public override int Constructor
        {
            get
            {
                return -341428482;
            }
        }

        public bool Self { get; set; }
        public bool VideoJoined { get; set; }
        public TLAbsPeer Peer { get; set; }
        
        public string About { get; set; }
        public long? RaiseHandRating { get; set; }
        public TLGroupCallParticipantVideo Video { get; set; }
        public TLGroupCallParticipantVideo Presentation { get; set; }


        public void ComputeFlags()
        {
            Flags = 0;
            Flags = Muted ? (Flags | 1) : (Flags & ~1);
            Flags = Left ? (Flags | 2) : (Flags & ~2);
            Flags = CanSelfUnmute ? (Flags | 4) : (Flags & ~4);
            Flags = JustJoined ? (Flags | 16) : (Flags & ~16);
            Flags = Versioned ? (Flags | 32) : (Flags & ~32);
            Flags = Min ? (Flags | 256) : (Flags & ~256);
            Flags = MutedByYou ? (Flags | 512) : (Flags & ~512);
            Flags = VolumeByAdmin ? (Flags | 1024) : (Flags & ~1024);
            Flags = Self ? (Flags | 4096) : (Flags & ~4096);
            Flags = VideoJoined ? (Flags | 32768) : (Flags & ~32768);
            Flags = ActiveDate != null ? (Flags | 8) : (Flags & ~8);
            Flags = Volume != null ? (Flags | 128) : (Flags & ~128);
            Flags = About != null ? (Flags | 2048) : (Flags & ~2048);
            Flags = RaiseHandRating != null ? (Flags | 8192) : (Flags & ~8192);
            Flags = Video != null ? (Flags | 64) : (Flags & ~64);
            Flags = Presentation != null ? (Flags | 16384) : (Flags & ~16384);

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
            Muted = (Flags & 1) != 0;
            Left = (Flags & 2) != 0;
            CanSelfUnmute = (Flags & 4) != 0;
            JustJoined = (Flags & 16) != 0;
            Versioned = (Flags & 32) != 0;
            Min = (Flags & 256) != 0;
            MutedByYou = (Flags & 512) != 0;
            VolumeByAdmin = (Flags & 1024) != 0;
            Self = (Flags & 4096) != 0;
            VideoJoined = (Flags & 32768) != 0;
            Peer = (TLAbsPeer)ObjectUtils.DeserializeObject(br);
            Date = br.ReadInt32();
            if ((Flags & 8) != 0)
                ActiveDate = br.ReadInt32();
            else
                ActiveDate = null;

            Source = br.ReadInt32();
            if ((Flags & 128) != 0)
                Volume = br.ReadInt32();
            else
                Volume = null;

            if ((Flags & 2048) != 0)
                About = StringUtil.Deserialize(br);
            else
                About = null;

            if ((Flags & 8192) != 0)
                RaiseHandRating = br.ReadInt64();
            else
                RaiseHandRating = null;

            if ((Flags & 64) != 0)
                Video = (TLGroupCallParticipantVideo)ObjectUtils.DeserializeObject(br);
            else
                Video = null;

            if ((Flags & 16384) != 0)
                Presentation = (TLGroupCallParticipantVideo)ObjectUtils.DeserializeObject(br);
            else
                Presentation = null;


        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ComputeFlags();
            bw.Write(Flags);

            ObjectUtils.SerializeObject(Peer, bw);
            bw.Write(Date);
            if ((Flags & 8) != 0)
                bw.Write(ActiveDate.Value);
            bw.Write(Source);
            if ((Flags & 128) != 0)
                bw.Write(Volume.Value);
            if ((Flags & 2048) != 0)
                StringUtil.Serialize(About, bw);
            if ((Flags & 8192) != 0)
                bw.Write(RaiseHandRating.Value);
            if ((Flags & 64) != 0)
                ObjectUtils.SerializeObject(Video, bw);
            if ((Flags & 16384) != 0)
                ObjectUtils.SerializeObject(Presentation, bw);

        }
    }
}
