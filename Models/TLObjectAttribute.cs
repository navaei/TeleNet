using System;

namespace TeleNet.Models
{
    public class TLObjectAttribute : Attribute
    {
        public int Constructor { get; private set; }
        
        public TLObjectAttribute(int Constructor)
        {
            this.Constructor = Constructor;
        }
    }
}
