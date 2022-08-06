using System.IO;

namespace TeleNet.Models.TL
{
    [TLObject(2086234950)]
    public class TLFileLocationUnavailable : TLAbsFileLocation
    {
        public override int Constructor
        {
            get
            {
                return 2086234950;
            }
        }

        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            VolumeId = br.ReadInt64();
            LocalId = br.ReadInt32();
            Secret = br.ReadInt64();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(VolumeId);
            bw.Write(LocalId);
            bw.Write(Secret);

        }
    }
}
