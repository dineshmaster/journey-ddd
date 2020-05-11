using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.RegularExpressions;

namespace Journey.Infrastructure.Validators
{
    public  class PhoneCountryCodeValidator:ValidatorBase
    {

        private Regex phoneCountryCodeExpression;
        public PhoneCountryCodeValidator()
        {
            phoneCountryCodeExpression = new Regex(@"^(\+\d{1,3})(\-\d{3,4})?$",RegExOption);
        }
        public  bool IsValid(string phoneCountryCode)
        {
            return phoneCountryCodeExpression.IsMatch(phoneCountryCode);
        }

        private static PhoneCountryCodeValidator _instance;
        public static PhoneCountryCodeValidator Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new PhoneCountryCodeValidator();
                return _instance;
            }
        }
    }
}
