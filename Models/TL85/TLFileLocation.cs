using TeleNet.Models.TL;
using System.IO;

namespace TeleNet.Models.TL85
{
    [TLObject(152900075)]
    public class TLFileLocation : TLAbsFileLocation
    {
        public override int Constructor
        {
            get
            {
                return 152900075;
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
            FileReference = BytesUtil.Deserialize(br);
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(DcId);
            bw.Write(VolumeId);
            bw.Write(LocalId);
            bw.Write(Secret);
            if (FileReference == null)
                FileReference = new byte[0];
            BytesUtil.Serialize(FileReference, bw);

        }
    }
}
