using Journey.Infrastructure.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Journey.Infrastructure.Validators
{
    public class InvalidPasswordException:ExceptionBase
    {
        private const string MESSAGE = "Invaild password";
        public InvalidPasswordException(string password):base(MESSAGE)
        {

        }
    }
}
