using System;

namespace TeleNet.Models
{
    public class InvalidPhoneCodeException : Exception
    {
        internal InvalidPhoneCodeException(string msg) : base(msg) { }
    }
}
