using System.IO;

namespace TeleNet.Models.TL.Auth
{
    [TLObject(-1616179942)]
    public class TLRequestResetAuthorizations : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return -1616179942;
            }
        }

        public bool Response { get; set; }


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
            Response = BoolUtil.Deserialize(br);

        }
    }
}
