using System;

namespace Fsl.NopCommerce.Api.Connector
{
    public class ApiSynchronizationException : Exception
    {
        public ApiSynchronizationException()
        {
        }

        public ApiSynchronizationException(string message) : base(message)
        {
        }

        public ApiSynchronizationException(string message, Exception inner) : base(message,inner)
        {

        }
    }
}
