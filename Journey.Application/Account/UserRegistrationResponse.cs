using System;
using System.Collections.Generic;
using System.Text;

namespace Journey.Application.Account
{
    public class CustomerSignUpResponse
    {
        public int CustomerId { get; set; }
        public bool TwoFARequired { get; set; } = true;
    }
}
