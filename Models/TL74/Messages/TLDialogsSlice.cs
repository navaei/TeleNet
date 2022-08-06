using System.IO;
using TeleNet.Models.TL.Messages;

namespace TeleNet.Models.TL.Messages
{
    [TLObject(1910543603)]
    public class TLDialogsSlice : TLAbsDialogs
    {
        public override int Constructor
        {
            get
            {
                return 1910543603;
            }
        }

        public int Count { get; set; }
        public TLVector<TLAbsDialog> Dialogs { get; set; }
        public TLVector<TLAbsMessage> Messages { get; set; }
        public TLVector<TLAbsChat> Chats { get; set; }
        public TLVector<TLAbsUser> Users { get; set; }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Count = br.ReadInt32();
            Dialogs = ObjectUtils.DeserializeVector<TLAbsDialog>(br);
            Messages = ObjectUtils.DeserializeVector<TLAbsMessage>(br);
            Chats = ObjectUtils.DeserializeVector<TLAbsChat>(br);
            Users = ObjectUtils.DeserializeVector<TLAbsUser>(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(Count);
            ObjectUtils.SerializeObject(Dialogs, bw);
            ObjectUtils.SerializeObject(Messages, bw);
            ObjectUtils.SerializeObject(Chats, bw);
            ObjectUtils.SerializeObject(Users, bw);

        }
    }
}
