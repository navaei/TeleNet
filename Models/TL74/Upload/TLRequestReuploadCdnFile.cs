using System.IO;

namespace TeleNet.Models.TL.Upload
{
    [TLObject(779755552)]
    public class TLRequestReuploadCdnFile : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return 779755552;
            }
        }

        public byte[] FileToken { get; set; }
        public byte[] RequestToken { get; set; }
        public bool Response { get; set; }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            FileToken = BytesUtil.Deserialize(br);
            RequestToken = BytesUtil.Deserialize(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            BytesUtil.Serialize(FileToken, bw);
            BytesUtil.Serialize(RequestToken, bw);

        }
        public override void DeserializeResponse(BinaryReader br)
        {
            Response = BoolUtil.Deserialize(br);

        }
    }
}
