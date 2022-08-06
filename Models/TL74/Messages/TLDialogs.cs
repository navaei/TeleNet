using System.IO;
using TeleNet.Models.TL.Messages;

namespace TeleNet.Models.TL.Messages
{
    [TLObject(364538944)]
    public class TLDialogs : TLAbsDialogs
    {
        public override int Constructor
        {
            get
            {
                return 364538944;
            }
        }

        public TLVector<TLAbsDialog> Dialogs { get; set; }
        public TLVector<TLAbsMessage> Messages { get; set; }
        public TLVector<TLAbsChat> Chats { get; set; }
        public TLVector<TLAbsUser> Users { get; set; }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Dialogs = ObjectUtils.DeserializeVector<TLAbsDialog>(br);
            Messages = ObjectUtils.DeserializeVector<TLAbsMessage>(br);
            Chats = ObjectUtils.DeserializeVector<TLAbsChat>(br);
            Users = ObjectUtils.DeserializeVector<TLAbsUser>(br);
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ObjectUtils.SerializeObject(Dialogs, bw);
            ObjectUtils.SerializeObject(Messages, bw);
            ObjectUtils.SerializeObject(Chats, bw);
            ObjectUtils.SerializeObject(Users, bw);
        }
    }
}
