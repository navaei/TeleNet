using System.IO;

namespace TeleNet.Models.TL
{
    [TLObject(-1503425638)]
    public class TLMessageActionChatCreate : TLAbsMessageAction
    {
        public override int Constructor
        {
            get
            {
                return -1503425638;
            }
        }

        public string Title { get; set; }
        public TLVector<int> Users { get; set; }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Title = StringUtil.Deserialize(br);
            Users = (TLVector<int>)ObjectUtils.DeserializeVector<int>(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            StringUtil.Serialize(Title, bw);
            ObjectUtils.SerializeObject(Users, bw);

        }
    }
}
