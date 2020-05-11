using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Journey.Domain.Model.Customer
{
    public interface ICustomerRepository
    {
        Task<CustomerSignUpResult> AddAsync(Customer customer);
        Task<bool> GenerateSignUpOTPAsync(CustomerOTP customerOTP);
    }
}
