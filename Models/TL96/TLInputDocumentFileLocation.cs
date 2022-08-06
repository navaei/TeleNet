using System.IO;
using TeleNet.Models.TL;
using  TeleNet.Models.TL;

namespace  TeleNet.Models.TL96
{
    [TLObject(426148825)]
    public class TLInputDocumentFileLocation : TLAbsInputFileLocation
    {
        public override int Constructor
        {
            get
            {
                return 426148825;
            }
        }

        public long Id { get; set; }
        public long AccessHash { get; set; }
        public byte[] FileReference { get; set; }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Id = br.ReadInt64();
            AccessHash = br.ReadInt64();
            FileReference = BytesUtil.Deserialize(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(Id);
            bw.Write(AccessHash);
            BytesUtil.Serialize(FileReference, bw);

        }
    }
}
