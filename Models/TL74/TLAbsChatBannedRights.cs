
namespace TeleNet.Models.TL
{
    public abstract class TLAbsChatBannedRights : TLObject
    {
        public int Flags { get; set; }
        public bool ViewMessages { get; set; }
        public bool SendMessages { get; set; }
        public bool SendMedia { get; set; }
        public bool SendStickers { get; set; }
        public bool SendGifs { get; set; }
        public bool SendGames { get; set; }
        public bool SendInline { get; set; }
        public bool EmbedLinks { get; set; }
        public bool SendPolls { get; set; }
        public bool ChangeInfo { get; set; }
        public bool InviteUsers { get; set; }
        public bool PinMessages { get; set; }
        public int UntilDate { get; set; }
    }
}