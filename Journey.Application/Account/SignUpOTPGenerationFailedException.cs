using Journey.Infrastructure.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Journey.Application.Account
{
    [Serializable]
    public class SignUpOTPGenerationFailedException : ExceptionBase
    {
        private const string MESSAGE = "Storing OTP {0} in database failed for customer {1} at {2}";
        public SignUpOTPGenerationFailedException(long otp, int customerId) : base(string.Format(MESSAGE, otp, customerId, DateTime.UtcNow))
        {

        }
    }
}
