using System;

namespace TeleNet.Models
{
    public class MissingApiConfigurationException : Exception
    {
        internal MissingApiConfigurationException(string invalidParamName) :
            base($"Your {invalidParamName} setting is missing. Adjust the configuration first")
        {
        }
    }
}
