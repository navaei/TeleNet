namespace TeleNet.Models.TL.Auth
{
    public abstract class TLAbsSentCode : TLObject
    {
        public int Flags { get; set; }
        public bool PhoneRegistered { get; set; }
        public Auth.TLAbsSentCodeType Type { get; set; }
        public string PhoneCodeHash { get; set; }
        public Auth.TLAbsCodeType NextType { get; set; }
        public int? Timeout { get; set; }
    }
}