using Journey.Infrastructure.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Journey.Infrastructure.Validators
{
    public class InvalidPhoneCountryCodeException : ExceptionBase
    {
        private const string MESSAGE = "Invalid phone number country code: {0}";
        public InvalidPhoneCountryCodeException(string phoneCountryCode) : base(string.Format(MESSAGE,phoneCountryCode))
        {
        }
    }
}
