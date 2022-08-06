using System.IO;
using TeleNet.Models.TL.Contacts;

namespace TeleNet.Models.TL.Contacts
{
    [TLObject(-176409329)]
    public class TLRequestGetBlocked : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return -176409329;
            }
        }

        public int Offset { get; set; }
        public int Limit { get; set; }
        public TLAbsBlocked Response { get; set; }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Offset = br.ReadInt32();
            Limit = br.ReadInt32();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(Offset);
            bw.Write(Limit);

        }
        public override void DeserializeResponse(BinaryReader br)
        {
            Response = (TLAbsBlocked)ObjectUtils.DeserializeObject(br);

        }
    }
}
