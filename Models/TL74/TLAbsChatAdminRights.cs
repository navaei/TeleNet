

namespace TeleNet.Models.TL
{
    public abstract class TLAbsChatAdminRights : TLObject
    {
        public int Flags { get; set; }
        public bool ChangeInfo { get; set; }
        public bool PostMessages { get; set; }
        public bool EditMessages { get; set; }
        public bool DeleteMessages { get; set; }
        public bool BanUsers { get; set; }
        public bool InviteUsers { get; set; }
        public bool PinMessages { get; set; }
        public bool AddAdmins { get; set; }
    }
}