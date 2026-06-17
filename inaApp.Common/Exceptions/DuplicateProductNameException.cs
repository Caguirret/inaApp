using System;
using System.Collections.Generic;
using System.Text;

namespace inaApp.Common.Exceptions
{
    public class DuplicateProductNameException : Exception
    {
        public DuplicateProductNameException()
        {
        }

        public DuplicateProductNameException(string? message) : base(message)
        {
        }
    }
}
