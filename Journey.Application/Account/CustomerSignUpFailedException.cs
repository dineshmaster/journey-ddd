using Journey.Domain.Model.Shared;
using Journey.Infrastructure.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Journey.Application.Account
{
    [Serializable]
    public class CustomerSignUpFailedException:ExceptionBase
    {
        private const string MESSAGE = "SignUp for Customer with email {0} at {1} ";
        public CustomerSignUpFailedException(EmailAddress customerEmail):base(string.Format(MESSAGE,customerEmail.Value,DateTime.UtcNow))
        {

        }
    }
}
