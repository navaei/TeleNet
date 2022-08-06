using System.IO;
using TeleNet.Models.TL;

namespace  TeleNet.Models.TL96
{
    [TLObject(-539317279)]
    public class TLInputFileLocation : TLAbsInputFileLocation
    {
        public override int Constructor
        {
            get
            {
                return -539317279;
            }
        }

        public long VolumeId { get; set; }
        public int LocalId { get; set; }
        public long Secret { get; set; }
        public byte[] FileReference { get; set; }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            VolumeId = br.ReadInt64();
            LocalId = br.ReadInt32();
            Secret = br.ReadInt64();
            FileReference = BytesUtil.Deserialize(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(VolumeId);
            bw.Write(LocalId);
            bw.Write(Secret);
            BytesUtil.Serialize(FileReference, bw);

        }
    }
}
