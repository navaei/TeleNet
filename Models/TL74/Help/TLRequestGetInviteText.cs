using System.IO;

namespace TeleNet.Models.TL.Help
{
    [TLObject(1295590211)]
    public class TLRequestGetInviteText : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return 1295590211;
            }
        }

        public Help.TLInviteText Response { get; set; }


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
            Response = (Help.TLInviteText)ObjectUtils.DeserializeObject(br);

        }
    }
}
