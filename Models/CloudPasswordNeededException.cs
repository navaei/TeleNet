using System;

namespace TeleNet.Models
{
    public class CloudPasswordNeededException : Exception
    {
        internal CloudPasswordNeededException(string msg) : base(msg) { }
    }
}
