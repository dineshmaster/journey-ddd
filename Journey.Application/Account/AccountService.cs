using Journey.Domain.Model.Customer;
using Journey.Domain.Model.Shared;
using Journey.Infrastructure.Common;
using Journey.Infrastructure.SMS;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<AccountService> Logger;
        public AccountService(ICustomerService customerSignUpService,
            ISMSService smsService,
            ICustomerRepository customerRepository,
            ISharedUtilities sharedUtilities,
            ILogger<AccountService> logger)
        {
            this.CustomerSignUpService = customerSignUpService;
            this.SMSService = smsService;
            this.CustomerRepository = customerRepository;
            this.SharedUtilities = sharedUtilities;
            this.Logger = logger;
        }
        public async Task<CustomerSignUpResponse> SignUpCustomerAsync(CustomerSignUpRequest userSignUpRequest)
        {
            CustomerSignUpResponse response = null;

            PhoneNumber phoneNumber = new PhoneNumber(userSignUpRequest.PhoneCode, userSignUpRequest.PhoneNumber);
            EmailAddress emailAddress = new EmailAddress(userSignUpRequest.EmailAddress);
            Password password = new Password(userSignUpRequest.Password);
            Customer customer = new Customer(emailAddress,phoneNumber,password);
            CustomerSignUpResult customerSignUpResult =await this.CustomerSignUpService.SignUpCustomerAsync(customer);

            if (customerSignUpResult == null || customerSignUpResult.CustomerSignUpStatus == CustomerSignUpStatus.Failed)
            {
                throw new CustomerSignUpFailedException(customer.EmailAddress);
            }
            if (customerSignUpResult.CustomerSignUpStatus == CustomerSignUpStatus.Registered)
            {
                await Task.Run(async() =>
                {
                    long otp = await GenerateOTPAsync(customerSignUpResult.CustomerId);
                    SMSService.SendSMS(string.Format(CustomerLiteral.PHONENUMBER_VERIFICATION_SMS, customer.PhoneNumber.PhoneNumberWithCode, otp)
                        , customer.PhoneNumber.PhoneNumberWithCode);
                });
            }
            
            response = new CustomerSignUpResponse
            {
                CustomerId = customerSignUpResult.CustomerId
            };
            return response;
        }
        public async Task<long> GenerateOTPAsync(int customerId)
        {
            long otp = SharedUtilities.GenerateOTPHaving(ApplicationConstants.OTP_LENGTH);
            DateTime validUpTo = DateTime.UtcNow.AddMinutes(ApplicationConstants.OTP_LIFE_IN_MINUTES);
            CustomerOTP customerOTP = new CustomerOTP(customerId, otp, validUpTo);
            if(!await CustomerRepository.GenerateSignUpOTPAsync(customerOTP))
            {
                throw new SignUpOTPGenerationFailedException(otp, customerId);
            }
            return otp;
        }
    }
}
