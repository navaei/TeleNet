using System.IO;

namespace TeleNet.Models.TL.Help
{
    [TLObject(-236044656)]
    public class TLTermsOfService : TLObject
    {
        public override int Constructor
        {
            get
            {
                return -236044656;
            }
        }

        public string Text { get; set; }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Text = StringUtil.Deserialize(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            StringUtil.Serialize(Text, bw);

        }
    }
}
