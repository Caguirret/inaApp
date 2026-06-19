using System;
using System.Collections.Generic;
using System.Text;

namespace inaApp.Common.Exceptions
{
    public class DuplicateClientException : Exception
    {
        public DuplicateClientException()
        {
        }

        public DuplicateClientException(string? message) : base(message)
        {
        }
    }
}
