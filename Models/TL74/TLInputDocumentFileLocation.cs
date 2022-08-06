using System.IO;

namespace TeleNet.Models.TL
{
    [TLObject(1125058340)]
    public class TLInputDocumentFileLocation : TLAbsInputFileLocation
    {
        public override int Constructor
        {
            get
            {
                return 1125058340;
            }
        }

        public long Id { get; set; }
        public long AccessHash { get; set; }
        public int Version { get; set; }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Id = br.ReadInt64();
            AccessHash = br.ReadInt64();
            Version = br.ReadInt32();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(Id);
            bw.Write(AccessHash);
            bw.Write(Version);

        }
    }
}
