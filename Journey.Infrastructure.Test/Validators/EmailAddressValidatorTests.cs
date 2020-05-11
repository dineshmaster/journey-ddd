using Journey.Infrastructure.Validators;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Journey.Infrastructure.Test.Validators
{
    public class EmailAddressValidatorTests
    {
        [Theory]
        [InlineData("tom.jhon@gmail.com")]
        [InlineData("sam123jhon@gmail.com")]
        [InlineData("d#$%&@gmail.com")]
        [InlineData("t0-9!#$%&'*+/=?^_jhon@gmail.com")]
        public void IsValid_proper_email_addresses(string emailAddress)
        {
            bool isValid = EmailAddressValidator.Instance.IsValid(emailAddress);
            Assert.True(isValid);
        }

        [Theory]
        [InlineData("jacobdaniel.gmail.com")]
        [InlineData("jgmail.com")]
        public void IsValid_incorrect_email_addresses(string emailAddress)
        {
            bool isValid = EmailAddressValidator.Instance.IsValid(emailAddress);
            Assert.False(isValid);
        }
    }
}
