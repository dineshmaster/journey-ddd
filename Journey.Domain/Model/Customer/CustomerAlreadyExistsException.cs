using Journey.Domain.Model.Shared;
using Journey.Infrastructure.Common;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Journey.Domain.Model.Customer
{
    public class CustomerAlreadyExistsException : ExceptionBase
    {
        private const string MESSAGE = "Customer with {0} already exists";
        private readonly PhoneNumber PhoneNumber;
        public CustomerAlreadyExistsException(PhoneNumber phoneNumber):base(string.Format(MESSAGE,$" phonenumber {phoneNumber.PhoneNumberWithCode}"))
        {
        }
        public CustomerAlreadyExistsException(EmailAddress emailAddress):base(string.Format(MESSAGE,$" email {emailAddress.Value}"))
        {

        }
        public CustomerAlreadyExistsException(PhoneNumber phoneNumber,EmailAddress emailAddress)
            :base(string.Format(MESSAGE,$" email {emailAddress.Value} and phone number {phoneNumber.PhoneNumberWithCode}"))
        {

        }
    }
}
