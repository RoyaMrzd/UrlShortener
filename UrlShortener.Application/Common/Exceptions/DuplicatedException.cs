using System;

namespace UrlShortener.Application.Common.Exceptions
{
    public class DuplicatedException : Exception
    {
        public DuplicatedException(string message)
            : base(message)
        {
        }
    }
}
