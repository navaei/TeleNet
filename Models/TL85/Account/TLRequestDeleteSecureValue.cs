using TeleNet.Models.TL;
using System.IO;

namespace TeleNet.Models.TL85.Account
{
    [TLObject(-1199522741)]
    public class TLRequestDeleteSecureValue : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return -1199522741;
            }
        }

        public TLVector<TLAbsSecureValueType> Types { get; set; }
        public bool Response { get; set; }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Types = (TLVector<TLAbsSecureValueType>)ObjectUtils.DeserializeVector<TLAbsSecureValueType>(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ObjectUtils.SerializeObject(Types, bw);

        }

        public override void DeserializeResponse(BinaryReader br)
        {
            Response = BoolUtil.Deserialize(br);

        }
    }
}
