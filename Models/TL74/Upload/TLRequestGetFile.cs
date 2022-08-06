using System.IO;
using TeleNet.Models.TL.Upload;

namespace TeleNet.Models.TL.Upload
{
    [TLObject(-475607115)]
    public class TLRequestGetFile : TLAbsRequestGetFile
    {
        public override int Constructor
        {
            get
            {
                return -475607115;
            }
        }

        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Location = (TLAbsInputFileLocation)ObjectUtils.DeserializeObject(br);
            Offset = br.ReadInt32();
            Limit = br.ReadInt32();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
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
