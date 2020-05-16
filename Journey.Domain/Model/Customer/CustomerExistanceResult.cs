using Journey.Domain.Model.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Journey.Domain.Model.Customer
{
    public class CustomerExistanceResult
    {
        public EmailAddress EmailAddress { get; set; }
        public PhoneNumber PhoneNumber { get; set; }
        public CustomerExistanceResult(EmailAddress emailAddress,PhoneNumber phoneNumber)
        {
            this.EmailAddress = emailAddress;
            this.PhoneNumber = phoneNumber;
        }
    }
}
