using System.IO;

namespace TeleNet.Models.TL.Account
{
    [TLObject(655677548)]
    public class TLRequestCheckUsername : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return 655677548;
            }
        }

        public string Username { get; set; }
        public bool Response { get; set; }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Username = StringUtil.Deserialize(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            StringUtil.Serialize(Username, bw);

        }
        public override void DeserializeResponse(BinaryReader br)
        {
            Response = BoolUtil.Deserialize(br);

        }
    }
}
