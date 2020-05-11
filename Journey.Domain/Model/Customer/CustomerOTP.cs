using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Journey.Domain.Model.Customer
{
    public class CustomerOTP
    {
        public int CustomerId { get; private set; }
        public long OTP { get; private set; }
        public DateTime ValidUpTo { get; private set; }
        public CustomerOTP(int customerId,long otp,DateTime validUpTo)
        {
            this.CustomerId = customerId;
            this.OTP = otp;
            this.ValidUpTo = validUpTo;
        }
    }
}
