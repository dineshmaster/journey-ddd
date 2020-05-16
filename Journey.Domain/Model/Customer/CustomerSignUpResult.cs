using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Journey.Domain.Model.Customer
{
    public class CustomerSignUpResult
    {
        public int CustomerId { get; private set; }
        public CustomerSignUpStatus CustomerSignUpStatus { get; set; }
        public CustomerSignUpResult(int customerId)
        {
            this.CustomerId = customerId;
            CustomerSignUpStatus = customerId>0?CustomerSignUpStatus.Registered:CustomerSignUpStatus.Failed;
        }
        public CustomerSignUpResult(int customerId,CustomerSignUpStatus customerSignUpStatus)
        {
            this.CustomerId = customerId;
            this.CustomerSignUpStatus = customerSignUpStatus;
        }
    }
}
