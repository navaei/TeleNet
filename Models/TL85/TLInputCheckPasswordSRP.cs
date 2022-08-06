using TeleNet.Models.TL;
using System.IO;

namespace TeleNet.Models.TL85
{
    [TLObject(-763367294)]
    public class TLInputCheckPasswordSRP : TLAbsInputCheckPasswordSRP
    {
        public override int Constructor
        {
            get
            {
                return -763367294;
            }
        }

        public long SrpId { get; set; }
        public byte[] A { get; set; }
        public byte[] M1 { get; set; }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            SrpId = br.ReadInt64();
            A = BytesUtil.Deserialize(br);
            M1 = BytesUtil.Deserialize(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(SrpId);
            BytesUtil.Serialize(A, bw);
            BytesUtil.Serialize(M1, bw);

        }
    }
}
