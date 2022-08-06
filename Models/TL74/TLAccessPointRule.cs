using System.IO;

namespace TeleNet.Models.TL
{
    [TLObject(1182381663)]
    public class TLAccessPointRule : TLObject
    {
        public override int Constructor
        {
            get
            {
                return 1182381663;
            }
        }

        public string PhonePrefixRules { get; set; }
        public int DcId { get; set; }
        public TLVector<TLIpPort> Ips { get; set; }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            PhonePrefixRules = StringUtil.Deserialize(br);
            DcId = br.ReadInt32();
            Ips = (TLVector<TLIpPort>)ObjectUtils.DeserializeVector<TLIpPort>(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            StringUtil.Serialize(PhonePrefixRules, bw);
            bw.Write(DcId);
            ObjectUtils.SerializeObject(Ips, bw);

        }
    }
}
