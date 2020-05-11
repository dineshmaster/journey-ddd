using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Journey.Infrastructure.Validators
{
    public  class EmailAddressValidator:ValidatorBase
    {
        private Regex emailExpression;
        public EmailAddressValidator()
        {
            emailExpression = new Regex(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z",RegExOption);
        }
        public bool IsValid(string emailAddress)
        {
            return emailExpression.IsMatch(emailAddress);
        }

        private  static EmailAddressValidator _instance;
        public static EmailAddressValidator Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new EmailAddressValidator();
                return _instance;
            }
        }
    }
}
