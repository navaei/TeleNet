using System.IO;
using TeleNet.Models.TL.Upload;

namespace TeleNet.Models.TL.Upload
{
    [TLObject(-290921362)]
    public class TLCdnFileReuploadNeeded : TLAbsCdnFile
    {
        public override int Constructor
        {
            get
            {
                return -290921362;
            }
        }

        public byte[] RequestToken { get; set; }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            RequestToken = BytesUtil.Deserialize(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            BytesUtil.Serialize(RequestToken, bw);

        }
    }
}
