using System.IO;

namespace TeleNet.Models.TL
{
    [TLObject(1072550713)]
    public class TLTrue : TLObject
    {
        public override int Constructor
        {
            get
            {
                return 1072550713;
            }
        }



        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);

        }
    }
}
