using System.IO;
using TeleNet.Models.TL.Messages;

namespace TeleNet.Models.TL.Messages
{
    [TLObject(-1663561404)]
    public class TLChatsSlice : TLAbsChats
    {
        public override int Constructor
        {
            get
            {
                return -1663561404;
            }
        }

        public int Count { get; set; }
        public TLVector<TLAbsChat> Chats { get; set; }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Count = br.ReadInt32();
            Chats = (TLVector<TLAbsChat>)ObjectUtils.DeserializeVector<TLAbsChat>(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(Count);
            ObjectUtils.SerializeObject(Chats, bw);

        }
    }
}
