namespace TeleNet.Models.TL.Contacts
{
    public abstract class TLAbsFound : TLObject
    {
        public TLVector<TLAbsPeer> Results { get; set; }
        public TLVector<TLAbsChat> Chats { get; set; }
        public TLVector<TLAbsUser> Users { get; set; }

    }
}
