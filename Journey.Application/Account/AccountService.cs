using Journey.Domain.Model.Customer;
using Journey.Infrastructure.Common;
using Journey.Infrastructure.SMS;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Journey.Application.Account
{
    public class AccountService : IAccountService
    {
        private readonly ICustomerService CustomerSignUpService;
        private readonly ISMSService SMSService;
        private readonly ICustomerRepository CustomerRepository;
        private readonly ISharedUtilities SharedUtilities;
        public AccountService(ICustomerService customerSignUpService,
            ISMSService smsService,
            ICustomerRepository customerRepository,
            ISharedUtilities sharedUtilities)
        {
            this.CustomerSignUpService = customerSignUpService;
            this.SMSService = smsService;
            this.CustomerRepository = customerRepository;
            this.SharedUtilities = sharedUtilities;
        }
        public async Task<CustomerSignUpResponse> SignUpCustomerAsync(CustomerSignUpRequest userRegistrationRequest)
        {
            CustomerSignUpResponse response = null;

            PhoneNumber phoneNumber = new PhoneNumber(userRegistrationRequest.PhoneCode, userRegistrationRequest.PhoneNumber);
            Customer customer = new Customer(userRegistrationRequest.EmailAddress,phoneNumber,userRegistrationRequest.Password);
            CustomerSignUpResult customerSignUpResult =await this.CustomerSignUpService.SignUpCustomerAsync(customer);

            if(customerSignUpResult.CustomerSignUpStatus == CustomerSignUpStatus.Registered)
            {
                long otp =await GenerateOTPAsync(customerSignUpResult.CustomerId);
                SMSService.SendSMS(string.Format(CustomerLiteral.PHONENUMBER_VERIFICATION_SMS, customer.PhoneNumber.PhoneNumberWithCode, otp)
                    ,customer.PhoneNumber.PhoneNumberWithCode);
            }
            if (customerSignUpResult.CustomerId == 0)
            {
                throw new Exception("User registration failed");
            }
            response = new CustomerSignUpResponse
            {
                CustomerId = customer.CustomerId
            };
            return response;
        }
        public async Task<long> GenerateOTPAsync(int customerId)
        {
            long otp = SharedUtilities.GenerateOTPHaving(ApplicationConstants.OTP_LENGTH);
            DateTime validUpTo = DateTime.UtcNow.AddMinutes(ApplicationConstants.OTP_LIFE_IN_MINUTES);
            await CustomerRepository.GenerateSignUpOTPAsync(customerId, otp, validUpTo);
            return otp;
        }
    }
}
