using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL133
{
    [TLObject(93890858)]
    public class TLInputGroupCallStream : TLAbsInputFileLocation
    {
        public override int Constructor
        {
            get
            {
                return 93890858;
            }
        }

        public int Flags { get; set; }
        public TL123.TLInputGroupCall Call { get; set; }
        public long TimeMs { get; set; }
        public int Scale { get; set; }
        public int? VideoChannel { get; set; }
        public int? VideoQuality { get; set; }


        public void ComputeFlags()
        {
            Flags = 0;
            Flags = VideoChannel != null ? (Flags | 1) : (Flags & ~1);
            Flags = VideoQuality != null ? (Flags | 1) : (Flags & ~1);

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
            Call = (TL123.TLInputGroupCall)ObjectUtils.DeserializeObject(br);
            TimeMs = br.ReadInt64();
            Scale = br.ReadInt32();
            if ((Flags & 1) != 0)
                VideoChannel = br.ReadInt32();
            else
                VideoChannel = null;

            if ((Flags & 1) != 0)
                VideoQuality = br.ReadInt32();
            else
                VideoQuality = null;


        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ComputeFlags();
            bw.Write(Flags);
            ObjectUtils.SerializeObject(Call, bw);
            bw.Write(TimeMs);
            bw.Write(Scale);
            if ((Flags & 1) != 0)
                bw.Write(VideoChannel.Value);
            if ((Flags & 1) != 0)
                bw.Write(VideoQuality.Value);

        }
    }
}
