using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL123.Photos
{
    [TLObject(-1980559511)]
    public class TLRequestUploadProfilePhoto : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return -1980559511;
            }
        }

        public int Flags { get; set; }
        public TLAbsInputFile File { get; set; }
        public TLAbsInputFile Video { get; set; }
        public double? VideoStartTs { get; set; }
        public TL.Photos.TLPhoto Response { get; set; }


        public void ComputeFlags()
        {
            Flags = 0;
            Flags = File != null ? (Flags | 1) : (Flags & ~1);
            Flags = Video != null ? (Flags | 2) : (Flags & ~2);
            Flags = VideoStartTs != null ? (Flags | 4) : (Flags & ~4);

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
            if ((Flags & 1) != 0)
                File = (TLAbsInputFile)ObjectUtils.DeserializeObject(br);
            else
                File = null;

            if ((Flags & 2) != 0)
                Video = (TLAbsInputFile)ObjectUtils.DeserializeObject(br);
            else
                Video = null;

            if ((Flags & 4) != 0)
                VideoStartTs = br.ReadDouble();
            else
                VideoStartTs = null;


        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ComputeFlags();
            bw.Write(Flags);
            if ((Flags & 1) != 0)
                ObjectUtils.SerializeObject(File, bw);
            if ((Flags & 2) != 0)
                ObjectUtils.SerializeObject(Video, bw);
            if ((Flags & 4) != 0)
                bw.Write(VideoStartTs.Value);

        }

        public override void DeserializeResponse(BinaryReader br)
        {
            Response = (TL.Photos.TLPhoto)ObjectUtils.DeserializeObject(br);
        }
    }
}
