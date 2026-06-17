using System;
using System.Collections.Generic;
using System.Text;

namespace inaApp.Common.Exceptions
{
    public class InvalidEmailExceptions : Exception
    {
        public InvalidEmailExceptions()
        {
        }

        public InvalidEmailExceptions(string? message) : base(message)
        {
        }
    }
}
