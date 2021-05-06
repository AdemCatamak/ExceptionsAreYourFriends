using System;

namespace ServiceWithException.Exceptions
{
    public class NotFoundException<T> : Exception
    {
        public NotFoundException()
            : base($"{nameof(T)} is not found")
        {
        }
    }
}