using System;
using System.Collections.Generic;
using System.Text;

namespace Journey.Domain.Model.Customer
{
    public static class CustomerLiteral
    {
        public static string PHONENUMBER_VERIFICATION_SMS = @"Greetings from Journey.com,"+Environment.NewLine+
                                                        "OTP for verifying you phone number {0} is {1}";
    }
}
