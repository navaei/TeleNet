using System.IO;

namespace  TeleNet.Models.TL85.Help
{
    [TLObject(1378703997)]
    public class TLRequestGetAppUpdate : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return 1378703997;
            }
        }

        public string Source { get; set; }
        public TeleNet.Models.TL.Help.TLAbsAppUpdate Response { get; set; }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Source = StringUtil.Deserialize(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            StringUtil.Serialize(Source, bw);

        }

        public override void DeserializeResponse(BinaryReader br)
        {
            Response = (TeleNet.Models.TL.Help.TLAbsAppUpdate)ObjectUtils.DeserializeObject(br);

        }
    }
}
