using System.IO;

namespace TeleNet.Models.TL
{
    [TLObject(1217033015)]
    public class TLMessageActionChatAddUser : TLAbsMessageAction
    {
        public override int Constructor
        {
            get
            {
                return 1217033015;
            }
        }

        public TLVector<int> Users { get; set; }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Users = (TLVector<int>)ObjectUtils.DeserializeVector<int>(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ObjectUtils.SerializeObject(Users, bw);

        }
    }
}
