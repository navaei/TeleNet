using System.IO;

namespace TeleNet.Models.TL
{
    [TLObject(314130811)]
    public class TLUpdateUserPhone : TLAbsUpdate
    {
        public override int Constructor
        {
            get
            {
                return 314130811;
            }
        }

        public int UserId { get; set; }
        public string Phone { get; set; }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            UserId = br.ReadInt32();
            Phone = StringUtil.Deserialize(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(UserId);
            StringUtil.Serialize(Phone, bw);

        }
    }
}
