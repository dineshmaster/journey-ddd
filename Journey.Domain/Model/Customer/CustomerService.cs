using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Journey.Domain.Model.Customer
{
    public class CustomerService:ICustomerService
    {
        private readonly ICustomerRepository CustomerRepository;
        public CustomerService(ICustomerRepository customerRepository)
        {
            this.CustomerRepository = customerRepository;
        }
        public async Task<CustomerSignUpResult> SignUpCustomerAsync(Customer customer)
        {
            return await CustomerRepository.AddAsync(customer);
        }
    }
}
