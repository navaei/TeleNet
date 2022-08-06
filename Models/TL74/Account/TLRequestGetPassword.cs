using System.IO;

namespace TeleNet.Models.TL.Account
{
    [TLObject(1418342645)]
    public class TLRequestGetPassword : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return 1418342645;
            }
        }

        public TLAbsPassword Response { get; set; }


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
            Response = (TLAbsPassword)ObjectUtils.DeserializeObject(br);

        }
    }
}
