
namespace TeleNet.Models.TL.Channels
{
    public abstract class TLAbsChannelParticipants : TLObject
    {
        public int Count { get; set; }
        public TLVector<TeleNet.Models.TL.TLAbsChannelParticipant> Participants { get; set; }
        public TLVector<TLAbsChat> Chats { get; set; }
        public TLVector<TLAbsUser> Users { get; set; }

    }
}
