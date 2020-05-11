using Journey.Infrastructure.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Journey.Infrastructure.Validators
{
    public class InvalidPhoneNumberException:ExceptionBase
    {
        private const string MESSAGE = "Invalid phone number: {0}";
        public InvalidPhoneNumberException(string phoneNumber):base(string.Format(MESSAGE,phoneNumber))
        {

        }
    }
}
