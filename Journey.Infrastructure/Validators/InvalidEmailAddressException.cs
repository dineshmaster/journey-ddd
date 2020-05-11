using Journey.Infrastructure.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Journey.Infrastructure.Validators
{
    public class InvalidEmailAddressException : ExceptionBase
    {
        private const string MESSAGE = "Invalid email address: {0}";
        public InvalidEmailAddressException(string emailAddress) : base(string.Format(MESSAGE,emailAddress))
        {
        }
    }
}
