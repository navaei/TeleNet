namespace TeleNet.Models.TL.Account
{
    public abstract class TLAbsPrivacyRules : TLObject
    {
        public TLVector<TLAbsPrivacyRule> Rules { get; set; }
        public TLVector<TLAbsUser> Users { get; set; }
    }
}