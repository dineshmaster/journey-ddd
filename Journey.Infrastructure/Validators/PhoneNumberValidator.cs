using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.RegularExpressions;

namespace Journey.Infrastructure.Validators
{
    public  class PhoneNumberValidator:ValidatorBase
    {
        private Regex phoneNumberExpression;
        public PhoneNumberValidator()
        {
            phoneNumberExpression = new Regex(@"^([0-9]{4,15})",RegExOption);
        }
        public  bool IsValid(string phoneNumber)
        {
            return phoneNumberExpression.IsMatch(phoneNumber);
        }

        private static PhoneNumberValidator _instance;
        public static PhoneNumberValidator Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new PhoneNumberValidator();
                return _instance;
            }
        }
    }
}
