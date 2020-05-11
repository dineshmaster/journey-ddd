using Journey.Infrastructure.Validators;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Journey.Infrastructure.Test.Validators
{
    public class PhoneNumberValidatorTests
    {
        [Theory]
        [InlineData("9544856521")]
        [InlineData("954485652112345")]
        [InlineData("485123456")]
        public void IsValid_proper_phone_numbers(string phoneNumber)
        {
            bool isValid = PhoneNumberValidator.Instance.IsValid(phoneNumber);
            Assert.True(isValid);
        }
        [Theory]
        [InlineData("485-1862862")]
        [InlineData("+919544856526")]
        public void IsValid_incorrect_phone_numbers(string phoneNumber)
        {
            bool isValid = PhoneNumberValidator.Instance.IsValid(phoneNumber);
            Assert.False(isValid);
        }
    }
}
