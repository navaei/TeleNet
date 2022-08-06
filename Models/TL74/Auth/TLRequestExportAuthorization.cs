using System.IO;

namespace TeleNet.Models.TL.Auth
{
    [TLObject(-440401971)]
    public class TLRequestExportAuthorization : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return -440401971;
            }
        }

        public int DcId { get; set; }
        public Auth.TLAbsExportedAuthorization Response { get; set; }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            DcId = br.ReadInt32();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(DcId);

        }
        public override void DeserializeResponse(BinaryReader br)
        {
            Response = (Auth.TLAbsExportedAuthorization)ObjectUtils.DeserializeObject(br);

        }
    }
}
