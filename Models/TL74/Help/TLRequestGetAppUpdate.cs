using System.IO;
using TeleNet.Models.TL.Help;

namespace TeleNet.Models.TL.Help
{
    [TLObject(-1372724842)]
    public class TLRequestGetAppUpdate : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return -1372724842;
            }
        }

        public TLAbsAppUpdate Response { get; set; }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);

        }
        public override void DeserializeResponse(BinaryReader br)
        {
            Response = (TLAbsAppUpdate)ObjectUtils.DeserializeObject(br);

        }
    }
}
