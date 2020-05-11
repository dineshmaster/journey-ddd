using Journey.Infrastructure.Validators;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Journey.Infrastructure.Test.Validators
{
    public class PasswordValidatorTests
    {
        [Theory]
        [InlineData("Value@123")]
        [InlineData("12#1er")]
        public void IsValid_proper_passwords(string password)
        {
            bool isValid = PasswordValidator.Instance.IsValid(password);
            Assert.True(isValid);
        }
        [Theory]
        [InlineData("Password@1")]
        [InlineData("Password@1lorem")]
        [InlineData("ab@12")]
        public void IsValdi_incorrect_passwords(string password)
        {
            bool isValid = PasswordValidator.Instance.IsValid(password);
            Assert.False(isValid);
        }
    }
}
