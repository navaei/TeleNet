using System.IO;

namespace TeleNet.Models.TL
{
    [TLObject(-886477832)]
    public class TLLabeledPrice : TLObject
    {
        public override int Constructor
        {
            get
            {
                return -886477832;
            }
        }

        public string Label { get; set; }
        public long Amount { get; set; }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Label = StringUtil.Deserialize(br);
            Amount = br.ReadInt64();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            StringUtil.Serialize(Label, bw);
            bw.Write(Amount);

        }
    }
}
