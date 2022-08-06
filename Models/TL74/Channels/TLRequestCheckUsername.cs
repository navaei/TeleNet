using System.IO;

namespace TeleNet.Models.TL.Channels
{
    [TLObject(283557164)]
    public class TLRequestCheckUsername : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return 283557164;
            }
        }

        public TLAbsInputChannel Channel { get; set; }
        public string Username { get; set; }
        public bool Response { get; set; }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Channel = (TLAbsInputChannel)ObjectUtils.DeserializeObject(br);
            Username = StringUtil.Deserialize(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ObjectUtils.SerializeObject(Channel, bw);
            StringUtil.Serialize(Username, bw);

        }
        public override void DeserializeResponse(BinaryReader br)
        {
            Response = BoolUtil.Deserialize(br);

        }
    }
}
