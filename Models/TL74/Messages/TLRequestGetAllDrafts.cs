using System.IO;

namespace TeleNet.Models.TL.Messages
{
    [TLObject(1782549861)]
    public class TLRequestGetAllDrafts : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return 1782549861;
            }
        }

        public TLAbsUpdates Response { get; set; }


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
            Response = (TLAbsUpdates)ObjectUtils.DeserializeObject(br);

        }
    }
}
