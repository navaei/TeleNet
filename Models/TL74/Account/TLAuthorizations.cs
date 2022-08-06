using System.IO;

namespace TeleNet.Models.TL.Account
{
    [TLObject(307276766)]
    public class TLAuthorizations : TLObject
    {
        public override int Constructor
        {
            get
            {
                return 307276766;
            }
        }

        public TLVector<TLAbsAuthorization> Authorizations { get; set; }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Authorizations = ObjectUtils.DeserializeVector<TLAbsAuthorization>(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ObjectUtils.SerializeObject(Authorizations, bw);

        }
    }
}
