using System.IO;

namespace TeleNet.Models.TL
{
    [TLObject(922273905)]
    public class TLDocumentEmpty : TLAbsDocument
    {
        public override int Constructor
        {
            get
            {
                return 922273905;
            }
        }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Id = br.ReadInt64();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(Id);

        }
    }
}
