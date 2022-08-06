using System.IO;

namespace TeleNet.Models.TL.Help
{
    [TLObject(1375900482)]
    public class TLRequestGetCdnConfig : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return 1375900482;
            }
        }

        public TLCdnConfig Response { get; set; }


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
            Response = (TLCdnConfig)ObjectUtils.DeserializeObject(br);

        }
    }
}
