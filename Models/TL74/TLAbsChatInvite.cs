namespace TeleNet.Models.TL
{
    public abstract class TLAbsChatInvite : TLObject
    {
        public int Flags { get; set; }
        public bool Channel { get; set; }
        public bool Broadcast { get; set; }
        public bool Public { get; set; }
        public bool Megagroup { get; set; }
        public bool RequestNeeded { get; set; }
        public string Title { get; set; }
        public TLAbsPhoto Photo { get; set; }
        public int ParticipantsCount { get; set; }
        public TLVector<TLAbsUser> Participants { get; set; }


    }
}
