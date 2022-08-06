using System.IO;

namespace TeleNet.Models.TL.Auth
{
    [TLObject(-543777747)]
    public class TLExportedAuthorization : TLAbsExportedAuthorization
    {
        public override int Constructor
        {
            get
            {
                return -543777747;
            }
        }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Id = br.ReadInt32();
            Bytes = BytesUtil.Deserialize(br);
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write((int)Id);
            BytesUtil.Serialize(Bytes, bw);

        }
    }
}
