using System.IO;
using TeleNet.Models.TL.Messages;

namespace TeleNet.Models.TL.Messages
{
    [TLObject(479598769)]
    public class TLRequestGetAllStickers : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return 479598769;
            }
        }

        public int Hash { get; set; }
        public TLAbsAllStickers Response { get; set; }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Hash = br.ReadInt32();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(Hash);

        }
        public override void DeserializeResponse(BinaryReader br)
        {
            Response = (TLAbsAllStickers)ObjectUtils.DeserializeObject(br);

        }
    }
}
