using System.IO;

namespace TeleNet.Models.TL
{
    [TLObject(1444661369)]
    public class TLContactBlocked : TLObject
    {
        public override int Constructor
        {
            get
            {
                return 1444661369;
            }
        }

        public int UserId { get; set; }
        public int Date { get; set; }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            UserId = br.ReadInt32();
            Date = br.ReadInt32();

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(UserId);
            bw.Write(Date);

        }
    }
}
