using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;
using TeleNet.Models.TL.Upload;

namespace TeleNet.Models.TL111.Upload
{
    [TLObject(-1319462148)]
    public class TLRequestGetFile : TL.Upload.TLAbsRequestGetFile
    {
        public override int Constructor
        {
            get
            {
                return -1319462148;
            }
        }

        public int Flags { get; set; }
        public bool Precise { get; set; }
        public bool CdnSupported { get; set; }


        public void ComputeFlags()
        {
            Flags = 0;
            Flags = Precise ? (Flags | 1) : (Flags & ~1);
            Flags = CdnSupported ? (Flags | 2) : (Flags & ~2);

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
            Precise = (Flags & 1) != 0;
            CdnSupported = (Flags & 2) != 0;
            Location = (TLAbsInputFileLocation)ObjectUtils.DeserializeObject(br);
            Offset = br.ReadInt32();
            Limit = br.ReadInt32();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ComputeFlags();
            bw.Write(Flags);


            ObjectUtils.SerializeObject(Location, bw);
            bw.Write(Offset);
            bw.Write(Limit);

        }

        public override void DeserializeResponse(BinaryReader br)
        {
            Response = (TLAbsFile)ObjectUtils.DeserializeObject(br);

        }
    }
}
