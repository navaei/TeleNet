using System.IO;

namespace TeleNet.Models.TL
{
    [TLObject(-1489818765)]
    public class TLUpdateUserName : TLAbsUpdate
    {
        public override int Constructor
        {
            get
            {
                return -1489818765;
            }
        }

        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            UserId = br.ReadInt32();
            FirstName = StringUtil.Deserialize(br);
            LastName = StringUtil.Deserialize(br);
            Username = StringUtil.Deserialize(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(UserId);
            StringUtil.Serialize(FirstName, bw);
            StringUtil.Serialize(LastName, bw);
            StringUtil.Serialize(Username, bw);

        }
    }
}
