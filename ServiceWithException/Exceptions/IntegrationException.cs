using System;

namespace ServiceWithException.Exceptions
{
    public class IntegrationException : Exception
    {
        public IntegrationException(string serviceName)
            : base($"{serviceName} connection error")
        {
        }
    }
}