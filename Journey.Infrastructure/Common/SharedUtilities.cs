using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Journey.Infrastructure.Common
{
    public class SharedUtilities : ISharedUtilities
    {
        private const int OTP_MAX_DIGIT_COUNT = 10;
        private const int OTP_MIN_DIGIT_COUNT = 1;
        private const string OTP_ARGUMENT_EXCEPTION_MESSAGE = "digits should be greater than {0} and less than or equal to {1}";
        public long GenerateOTPHaving(int digits=6)
        {
            if (digits <= 0 || digits > OTP_MAX_DIGIT_COUNT)
                throw new ArgumentException(string.Format(OTP_ARGUMENT_EXCEPTION_MESSAGE, OTP_MIN_DIGIT_COUNT,OTP_MAX_DIGIT_COUNT));
            int min = OTP_MIN_DIGIT_COUNT;
            if(digits > min)
            {
                for(int i = 1; i < digits; i++)
                {
                    min = min * 10;
                }
            }

            int max = (min * 10) ;

            long randomOtp = new Random().Next(min, max);
            return randomOtp;
        }
    }
}
