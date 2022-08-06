using TeleNet.Models.TL;
using System.IO;

namespace  TeleNet.Models.TL85.Account
{
    [TLObject(1151208273)]
    public class TLRequestGetTmpPassword : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return 1151208273;
            }
        }

        public TLAbsInputCheckPasswordSRP Password { get; set; }
        public int Period { get; set; }
        public TeleNet.Models.TL.Account.TLTmpPassword Response { get; set; }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Password = (TLAbsInputCheckPasswordSRP)ObjectUtils.DeserializeObject(br);
            Period = br.ReadInt32();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ObjectUtils.SerializeObject(Password, bw);
            bw.Write(Period);

        }

        public override void DeserializeResponse(BinaryReader br)
        {
            Response = (TeleNet.Models.TL.Account.TLTmpPassword)ObjectUtils.DeserializeObject(br);

        }
    }
}
