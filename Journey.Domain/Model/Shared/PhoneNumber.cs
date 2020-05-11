using Journey.Domain.Model.Base;
using Journey.Infrastructure.Validators;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace Journey.Domain.Model.Shared
{
    public class PhoneNumber:ValueObject
    {

        public string PhoneCode { get; private set; }
        public string Number { get; private set; }
        public string PhoneNumberWithCode { 
            get
            {
                return $"{PhoneCode}{Number}";
            }
        }
        public PhoneNumber(string phoneCode,string number)
        {
            if (string.IsNullOrWhiteSpace(phoneCode)) 
                throw new ArgumentNullException("Phone number country code cannot be blank");
            if (string.IsNullOrWhiteSpace(number))
                throw new ArgumentNullException("Phone number cannot be blank");
            if (!PhoneNumberValidator.Instance.IsValid(number))
                throw new InvalidPhoneNumberException(number);
            if (!PhoneCountryCodeValidator.Instance.IsValid(phoneCode))
                throw new InvalidPhoneCountryCodeException(phoneCode);
            this.PhoneCode = phoneCode;
            this.Number = number;
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return PhoneCode;
            yield return Number;
        }
    }
}
