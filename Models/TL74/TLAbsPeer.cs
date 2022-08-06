namespace TeleNet.Models.TL
{
    public abstract class TLAbsPeer : TLObject
    {
        public static implicit operator TLAbsPeer(int id) =>
              new TLPeerUser() { UserId = id };

        public static implicit operator int(TLAbsPeer peer) => peer is null ? 0 :
            peer is TLAbsPeerChannel channel ? (int)channel.ChannelId :
            peer is TLPeerChat chat ? chat.ChatId :
           (int)((TLAbsPeerUser)peer).UserId;
    }
}
