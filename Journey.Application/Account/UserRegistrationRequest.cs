using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Journey.Application.Account
{
    public class CustomerSignUpRequest
    {
        [EmailAddress]
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string PhoneCode { get; set; }
    }
}
