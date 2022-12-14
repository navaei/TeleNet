using System.IO;

namespace TeleNet.Models.TL.Auth
{
    [TLObject(326715557)]
    public class TLPasswordRecovery : TLObject
    {
        public override int Constructor
        {
            get
            {
                return 326715557;
            }
        }

        public string EmailPattern { get; set; }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            EmailPattern = StringUtil.Deserialize(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            StringUtil.Serialize(EmailPattern, bw);

        }
    }
}
