using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Journey.Domain.Model.Customer
{
    public interface ICustomerRepository
    {
        Task<CustomerSignUpResult> AddAsync(Customer customer);
        Task GenerateSignUpOTPAsync(int customerId, long otp, DateTime validUpTo);
    }
}
