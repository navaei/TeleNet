using System.IO;

namespace TeleNet.Models.TL.Updates
{
    [TLObject(-304838614)]
    public class TLRequestGetState : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return -304838614;
            }
        }

        public Updates.TLState Response { get; set; }


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
            Response = (Updates.TLState)ObjectUtils.DeserializeObject(br);

        }
    }
}
