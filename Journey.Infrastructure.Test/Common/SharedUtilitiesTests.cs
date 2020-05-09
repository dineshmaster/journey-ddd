using Journey.Infrastructure.Common;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Journey.Infrastructure.Test.Common
{
    public class SharedUtilitiesTests
    {
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        [InlineData(6)]
        [InlineData(7)]
        [InlineData(8)]
        [InlineData(9)]
        [InlineData(10)]
        public void GenerateOTPHaving_with_proper_range_digits(int digits)
        {
            ISharedUtilities sharedUtilities = new SharedUtilities();
            long otp = 0;
            for(int i = 0; i < 100000; i++)
            {
                otp = sharedUtilities.GenerateOTPHaving(digits);
                Assert.True(otp.ToString().Length== digits);
            }
        }
        [Fact]
        public void GenerateOTPHaving_with_negative_range()
        {
            int digits = -1;
            ISharedUtilities sharedUtilities = new SharedUtilities();
            try
            {
                long otp = 0;
                for (int i = 0; i < 100000; i++)
                {
                    otp = sharedUtilities.GenerateOTPHaving(digits);
                    Assert.True(otp.ToString().Length == digits);
                }
            }
            catch (Exception ex)
            {

                Assert.Equal(typeof(ArgumentException), ex.GetType());
            }
        }
        [Fact]
        public void GenerateOTPHaving_with_range_exceeds_maximum()
        {
            int digits = 11;
            ISharedUtilities sharedUtilities = new SharedUtilities();
            try
            {
                long otp = 0;
                for (int i = 0; i < 100000; i++)
                {
                    otp = sharedUtilities.GenerateOTPHaving(digits);
                    Assert.True(otp.ToString().Length == digits);
                }
            }
            catch (Exception ex)
            {

                Assert.Equal(typeof(ArgumentException), ex.GetType());
            }
        }
    }
}
