using Journey.Infrastructure.Validators;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Journey.Infrastructure.Test.Validators
{
    public class PhoneCountryCodeValidatorTests
    {
        [Theory]
        [InlineData("+1-809")]
        [InlineData("+7")]
        [InlineData("+44-1481")]
        [InlineData("+592")]
        public void IsValid_proper_phone_coutry_codes(string phoneCountryCode)
        {
            bool isValid = PhoneCountryCodeValidator.Instance.IsValid(phoneCountryCode);
            Assert.True(isValid);
        }
        [Theory]
        [InlineData("+1234")]
        [InlineData("+123-12")]
        [InlineData("+abc")]
        [InlineData("123-")]
        public void IsValid_incorrect_phone_country_codes(string phoneCountryCode)
        {
            bool isValid = PhoneCountryCodeValidator.Instance.IsValid(phoneCountryCode);
            Assert.False(isValid);
        }
    }
}
