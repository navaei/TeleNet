using System.IO;

namespace TeleNet.Models.TL
{
    [TLObject(1406570614)]
    public class TLFileLocation : TLAbsFileLocation
    {
        public override int Constructor
        {
            get
            {
                return 1406570614;
            }
        }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            DcId = br.ReadInt32();
            VolumeId = br.ReadInt64();
            LocalId = br.ReadInt32();
            Secret = br.ReadInt64();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(DcId);
            bw.Write(VolumeId);
            bw.Write(LocalId);
            bw.Write(Secret);

        }
    }
}
