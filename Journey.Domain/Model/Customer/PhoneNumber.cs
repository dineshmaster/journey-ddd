using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace Journey.Domain.Model.Customer
{
    public class PhoneNumber
    {
        public string PhoneCode { get; private set; }
        public string Number { get; set; }
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
            this.PhoneCode = phoneCode;
            this.Number = number;
        }
    }
}
