using System.IO;

namespace TeleNet.Models.TL
{
    [TLObject(524838915)]
    public class TLExportedMessageLink : TLObject
    {
        public override int Constructor
        {
            get
            {
                return 524838915;
            }
        }

        public string Link { get; set; }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Link = StringUtil.Deserialize(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            StringUtil.Serialize(Link, bw);

        }
    }
}
