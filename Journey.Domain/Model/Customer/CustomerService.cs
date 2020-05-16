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
            CustomerSignUpResult customerSignUpResult = null;
            CustomerExistanceResult customerExistanceResult = await CustomerRepository.CustomerExistsAysnc(customer);
            if (customerExistanceResult==null)
            {
                customerSignUpResult = await CustomerRepository.AddAsync(customer);
            }
            else
            {
                if(customerExistanceResult.EmailAddress.Equals(customer.EmailAddress) 
                    && customerExistanceResult.PhoneNumber.Equals(customer.PhoneNumber))
                {
                    throw new CustomerAlreadyExistsException(customer.PhoneNumber, customer.EmailAddress);
                }
                if (customerExistanceResult.EmailAddress.Equals(customer.EmailAddress))
                {
                    throw new CustomerAlreadyExistsException(customer.EmailAddress);
                }
                if (customerExistanceResult.PhoneNumber.Equals(customer.PhoneNumber))
                {
                    throw new CustomerAlreadyExistsException(customer.PhoneNumber);
                }
            }
            if (customerSignUpResult == null || customerSignUpResult.CustomerSignUpStatus == CustomerSignUpStatus.Failed)
            {
                throw new CustomerSignUpFailedException(customer.EmailAddress);
            }

            return customerSignUpResult;
        }
    }
}
