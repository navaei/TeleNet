using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL133
{
    [TLObject(-711498484)]
    public class TLGroupCall : TeleNet.Models.TL.TLAbsGroupCall
    {
        public override int Constructor
        {
            get
            {
                return -711498484;
            }
        }

        public bool ScheduleStartSubscribed { get; set; }
        public bool CanStartVideo { get; set; }
        public bool RecordVideoActive { get; set; }
        public string Title { get; set; }
        public int? StreamDcId { get; set; }
        public int? RecordStartDate { get; set; }
        public int? ScheduleDate { get; set; }
        public int? UnmutedVideoCount { get; set; }
        public int UnmutedVideoLimit { get; set; }
        public int Version { get; set; }


        public void ComputeFlags()
        {
            Flags = 0;
            Flags = JoinMuted ? (Flags | 2) : (Flags & ~2);
            Flags = CanChangeJoinMuted ? (Flags | 4) : (Flags & ~4);
            Flags = JoinDateAsc ? (Flags | 64) : (Flags & ~64);
            Flags = ScheduleStartSubscribed ? (Flags | 256) : (Flags & ~256);
            Flags = CanStartVideo ? (Flags | 512) : (Flags & ~512);
            Flags = RecordVideoActive ? (Flags | 2048) : (Flags & ~2048);
            Flags = Title != null ? (Flags | 8) : (Flags & ~8);
            Flags = StreamDcId != null ? (Flags | 16) : (Flags & ~16);
            Flags = RecordStartDate != null ? (Flags | 32) : (Flags & ~32);
            Flags = ScheduleDate != null ? (Flags | 128) : (Flags & ~128);
            Flags = UnmutedVideoCount != null ? (Flags | 1024) : (Flags & ~1024);

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
            JoinMuted = (Flags & 2) != 0;
            CanChangeJoinMuted = (Flags & 4) != 0;
            JoinDateAsc = (Flags & 64) != 0;
            ScheduleStartSubscribed = (Flags & 256) != 0;
            CanStartVideo = (Flags & 512) != 0;
            RecordVideoActive = (Flags & 2048) != 0;
            Id = br.ReadInt64();
            AccessHash = br.ReadInt64();
            ParticipantsCount = br.ReadInt32();
            if ((Flags & 8) != 0)
                Title = StringUtil.Deserialize(br);
            else
                Title = null;

            if ((Flags & 16) != 0)
                StreamDcId = br.ReadInt32();
            else
                StreamDcId = null;

            if ((Flags & 32) != 0)
                RecordStartDate = br.ReadInt32();
            else
                RecordStartDate = null;

            if ((Flags & 128) != 0)
                ScheduleDate = br.ReadInt32();
            else
                ScheduleDate = null;

            if ((Flags & 1024) != 0)
                UnmutedVideoCount = br.ReadInt32();
            else
                UnmutedVideoCount = null;

            UnmutedVideoLimit = br.ReadInt32();
            Version = br.ReadInt32();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ComputeFlags();
            bw.Write(Flags);






            bw.Write(Id);
            bw.Write(AccessHash);
            bw.Write(ParticipantsCount);
            if ((Flags & 8) != 0)
                StringUtil.Serialize(Title, bw);
            if ((Flags & 16) != 0)
                bw.Write(StreamDcId.Value);
            if ((Flags & 32) != 0)
                bw.Write(RecordStartDate.Value);
            if ((Flags & 128) != 0)
                bw.Write(ScheduleDate.Value);
            if ((Flags & 1024) != 0)
                bw.Write(UnmutedVideoCount.Value);
            bw.Write(UnmutedVideoLimit);
            bw.Write(Version);

        }
    }
}
