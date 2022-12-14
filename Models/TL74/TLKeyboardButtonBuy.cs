using System.IO;

namespace TeleNet.Models.TL
{
    [TLObject(-1344716869)]
    public class TLKeyboardButtonBuy : TLAbsKeyboardButton
    {
        public override int Constructor
        {
            get
            {
                return -1344716869;
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
