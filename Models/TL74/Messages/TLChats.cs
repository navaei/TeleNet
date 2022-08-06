using System.IO;
using TeleNet.Models.TL.Messages;

namespace TeleNet.Models.TL.Messages
{
    [TLObject(1694474197)]
    public class TLChats : TLAbsChats
    {
        public override int Constructor
        {
            get
            {
                return 1694474197;
            }
        }

        public TLVector<TLAbsChat> Chats { get; set; }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Chats = (TLVector<TLAbsChat>)ObjectUtils.DeserializeVector<TLAbsChat>(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ObjectUtils.SerializeObject(Chats, bw);

        }
    }
}
