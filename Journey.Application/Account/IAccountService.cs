using Journey.Application.Account.Request;
using Journey.Application.Account.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Journey.Application.Account
{
    public interface IAccountService
    {
        Task<CustomerSignUpResponse> SignUpCustomerAsync(CustomerSignUpRequest userRegistrationRequest);
        Task<long> GenerateOTPAsync(int customerId);
    }
}
